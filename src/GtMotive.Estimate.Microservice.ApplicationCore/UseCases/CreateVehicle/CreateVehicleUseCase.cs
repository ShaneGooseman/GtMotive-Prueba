using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Handles the creation of a new vehicle in the fleet.
    /// </summary>
    public sealed class CreateVehicleUseCase : IUseCase<CreateVehicleInput>, IRequestHandler<CreateVehicleInput, Unit>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICreateVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="outputPort">The output port.</param>
        public CreateVehicleUseCase(IVehicleRepository vehicleRepository, ICreateVehicleOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(CreateVehicleInput request, CancellationToken cancellationToken)
        {
            await Execute(request);
            return Unit.Value;
        }

        /// <inheritdoc/>
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = new Vehicle(
                Guid.NewGuid(),
                input.LicensePlate,
                input.Brand,
                input.Model,
                input.ManufacturingDate);

            await _vehicleRepository.AddAsync(vehicle);

            _outputPort.StandardHandle(new CreateVehicleOutput(
                vehicle.Id,
                vehicle.LicensePlate,
                vehicle.Brand,
                vehicle.Model,
                vehicle.ManufacturingDate,
                vehicle.Status));
        }
    }
}
