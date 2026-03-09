using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input data for the RentVehicle use case.
    /// </summary>
    public sealed class RentVehicleInput : IUseCaseInput, IRequest<Unit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        public RentVehicleInput(Guid vehicleId, string customerId)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
        }

        /// <summary>Gets the vehicle identifier.</summary>
        public Guid VehicleId { get; }

        /// <summary>Gets the customer identifier.</summary>
        public string CustomerId { get; }
    }
}
