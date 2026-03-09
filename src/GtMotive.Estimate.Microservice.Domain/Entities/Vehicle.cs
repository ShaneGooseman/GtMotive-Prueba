#nullable enable
using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle in the rental fleet.
    /// </summary>
    public sealed class Vehicle
    {
        private const int MaxVehicleAgeYears = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="licensePlate">Vehicle license plate.</param>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="model">Vehicle model.</param>
        /// <param name="manufacturingDate">Date of manufacture.</param>
        public Vehicle(Guid id, string licensePlate, string brand, string model, DateTime manufacturingDate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
            {
                throw new DomainException("License plate is required.");
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new DomainException("Brand is required.");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new DomainException("Model is required.");
            }

            if (IsOlderThanMaxAge(manufacturingDate))
            {
                throw new DomainException($"Vehicle manufacturing date cannot be older than {MaxVehicleAgeYears} years.");
            }

            Id = id;
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
            Status = VehicleStatus.Available;
        }

        /// <summary>Gets the vehicle unique identifier.</summary>
        public Guid Id { get; }

        /// <summary>Gets the license plate.</summary>
        public string LicensePlate { get; }

        /// <summary>Gets the brand.</summary>
        public string Brand { get; }

        /// <summary>Gets the model.</summary>
        public string Model { get; }

        /// <summary>Gets the manufacturing date.</summary>
        public DateTime ManufacturingDate { get; }

        /// <summary>Gets the current rental status.</summary>
        public VehicleStatus Status { get; private set; }

        /// <summary>Gets the identifier of the customer currently renting the vehicle, if any.</summary>
        public string? CurrentCustomerId { get; private set; }

        /// <summary>
        /// Rents the vehicle to the specified customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public void Rent(string customerId)
        {
            if (Status != VehicleStatus.Available)
            {
                throw new DomainException("Vehicle is not available for renting.");
            }

            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new DomainException("Customer ID is required.");
            }

            Status = VehicleStatus.Rented;
            CurrentCustomerId = customerId;
        }

        /// <summary>
        /// Returns the vehicle, making it available again.
        /// </summary>
        public void Return()
        {
            if (Status != VehicleStatus.Rented)
            {
                throw new DomainException("Vehicle is not currently rented.");
            }

            Status = VehicleStatus.Available;
            CurrentCustomerId = null;
        }

        private static bool IsOlderThanMaxAge(DateTime manufacturingDate)
        {
            return manufacturingDate < DateTime.UtcNow.AddYears(-MaxVehicleAgeYears);
        }
    }
}
