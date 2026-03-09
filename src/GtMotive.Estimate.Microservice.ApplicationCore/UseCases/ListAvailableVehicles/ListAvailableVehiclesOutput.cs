using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Output data produced by the ListAvailableVehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">The list of available vehicles.</param>
        public ListAvailableVehiclesOutput(IReadOnlyCollection<VehicleItem> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>Gets the available vehicles.</summary>
        public IReadOnlyCollection<VehicleItem> Vehicles { get; }
    }
}
