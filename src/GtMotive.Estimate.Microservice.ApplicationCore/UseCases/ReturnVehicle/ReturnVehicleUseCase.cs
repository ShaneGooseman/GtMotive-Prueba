using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Handles the return of a rented vehicle, restoring its availability.
    /// </summary>
    public sealed class ReturnVehicleUseCase : IUseCase<ReturnVehicleInput>, IRequestHandler<ReturnVehicleInput, Unit>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IReturnVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="outputPort">The output port.</param>
        public ReturnVehicleUseCase(IVehicleRepository vehicleRepository, IReturnVehicleOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(ReturnVehicleInput request, CancellationToken cancellationToken)
        {
            await Execute(request);
            return Unit.Value;
        }

        /// <inheritdoc/>
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await _vehicleRepository.GetByIdAsync(input.VehicleId);
            if (vehicle == null)
            {
                _outputPort.NotFoundHandle($"Vehicle '{input.VehicleId}' was not found.");
                return;
            }

            vehicle.Return();
            await _vehicleRepository.UpdateAsync(vehicle);

            _outputPort.StandardHandle(new ReturnVehicleOutput(vehicle.Id, vehicle.Status));
        }
    }
}
