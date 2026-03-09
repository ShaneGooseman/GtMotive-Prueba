using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output data produced by the CreateVehicle use case.
    /// </summary>
    public sealed class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="id">The generated vehicle identifier.</param>
        /// <param name="licensePlate">Vehicle license plate.</param>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="model">Vehicle model.</param>
        /// <param name="manufacturingDate">Date of manufacture.</param>
        /// <param name="status">Current vehicle status.</param>
        public CreateVehicleOutput(
            Guid id,
            string licensePlate,
            string brand,
            string model,
            DateTime manufacturingDate,
            VehicleStatus status)
        {
            Id = id;
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
            Status = status;
        }

        /// <summary>Gets the vehicle identifier.</summary>
        public Guid Id { get; }

        /// <summary>Gets the license plate.</summary>
        public string LicensePlate { get; }

        /// <summary>Gets the brand.</summary>
        public string Brand { get; }

        /// <summary>Gets the model.</summary>
        public string Model { get; }

        /// <summary>Gets the manufacturing date.</summary>
        public DateTime ManufacturingDate { get; }

        /// <summary>Gets the vehicle status.</summary>
        public VehicleStatus Status { get; }
    }
}
