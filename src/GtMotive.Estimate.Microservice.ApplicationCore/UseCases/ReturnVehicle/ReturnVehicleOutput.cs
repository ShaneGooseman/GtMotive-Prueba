using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output data produced by the ReturnVehicle use case.
    /// </summary>
    public sealed class ReturnVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="status">The updated vehicle status.</param>
        public ReturnVehicleOutput(Guid vehicleId, VehicleStatus status)
        {
            VehicleId = vehicleId;
            Status = status;
        }

        /// <summary>Gets the vehicle identifier.</summary>
        public Guid VehicleId { get; }

        /// <summary>Gets the updated vehicle status.</summary>
        public VehicleStatus Status { get; }
    }
}
