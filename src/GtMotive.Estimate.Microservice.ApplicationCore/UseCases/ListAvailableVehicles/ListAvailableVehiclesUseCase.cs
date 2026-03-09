using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Returns all vehicles currently available for renting.
    /// </summary>
    public sealed class ListAvailableVehiclesUseCase : IUseCase<ListAvailableVehiclesInput>, IRequestHandler<ListAvailableVehiclesInput, Unit>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IListAvailableVehiclesOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="outputPort">The output port.</param>
        public ListAvailableVehiclesUseCase(
            IVehicleRepository vehicleRepository,
            IListAvailableVehiclesOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(ListAvailableVehiclesInput request, CancellationToken cancellationToken)
        {
            await Execute(request);
            return Unit.Value;
        }

        /// <inheritdoc/>
        public async Task Execute(ListAvailableVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicles = await _vehicleRepository.GetAvailableAsync();

            var items = vehicles.Select(v => new VehicleItem
            {
                Id = v.Id,
                LicensePlate = v.LicensePlate,
                Brand = v.Brand,
                Model = v.Model,
                ManufacturingDate = v.ManufacturingDate,
                Status = v.Status,
            }).ToList().AsReadOnly();

            _outputPort.StandardHandle(new ListAvailableVehiclesOutput(items));
        }
    }
}
