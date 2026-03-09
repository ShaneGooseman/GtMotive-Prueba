using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Input data for the ListAvailableVehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesInput : IUseCaseInput, IRequest<Unit>
    {
    }
}
