using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output data produced by the RentVehicle use case.
    /// </summary>
    public sealed class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="status">The updated vehicle status.</param>
        public RentVehicleOutput(Guid vehicleId, string customerId, VehicleStatus status)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
            Status = status;
        }

        /// <summary>Gets the vehicle identifier.</summary>
        public Guid VehicleId { get; }

        /// <summary>Gets the customer identifier.</summary>
        public string CustomerId { get; }

        /// <summary>Gets the updated vehicle status.</summary>
        public VehicleStatus Status { get; }
    }
}
