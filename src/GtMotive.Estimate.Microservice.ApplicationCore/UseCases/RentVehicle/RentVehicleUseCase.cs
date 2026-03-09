using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Handles the renting of an available vehicle to a customer.
    /// Enforces the domain rule that a customer may not rent more than one vehicle at a time.
    /// </summary>
    public sealed class RentVehicleUseCase : IUseCase<RentVehicleInput>, IRequestHandler<RentVehicleInput, Unit>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="outputPort">The output port.</param>
        public RentVehicleUseCase(IVehicleRepository vehicleRepository, IRentVehicleOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(RentVehicleInput request, CancellationToken cancellationToken)
        {
            await Execute(request);
            return Unit.Value;
        }

        /// <inheritdoc/>
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var existingRental = await _vehicleRepository.GetRentedByCustomerAsync(input.CustomerId);
            if (existingRental != null)
            {
                throw new DomainException("Customer already has an active rental.");
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(input.VehicleId);
            if (vehicle == null)
            {
                _outputPort.NotFoundHandle($"Vehicle '{input.VehicleId}' was not found.");
                return;
            }

            vehicle.Rent(input.CustomerId);
            await _vehicleRepository.UpdateAsync(vehicle);

            _outputPort.StandardHandle(new RentVehicleOutput(vehicle.Id, vehicle.CurrentCustomerId!, vehicle.Status));
        }
    }
}
