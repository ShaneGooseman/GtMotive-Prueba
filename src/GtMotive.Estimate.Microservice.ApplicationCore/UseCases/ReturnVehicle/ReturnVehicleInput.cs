using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Input data for the ReturnVehicle use case.
    /// </summary>
    public sealed class ReturnVehicleInput : IUseCaseInput, IRequest<Unit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        public ReturnVehicleInput(Guid vehicleId)
        {
            VehicleId = vehicleId;
        }

        /// <summary>Gets the vehicle identifier.</summary>
        public Guid VehicleId { get; }
    }
}
