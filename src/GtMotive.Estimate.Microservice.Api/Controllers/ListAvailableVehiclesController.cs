using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Handles listing of available vehicles.
    /// </summary>
    [ApiController]
    [Route("api/vehicles")]
    public sealed class ListAvailableVehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ListAvailableVehiclesPresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesController"/> class.
        /// </summary>
        /// <param name="mediator">The MediatR mediator.</param>
        /// <param name="presenter">The output presenter.</param>
        public ListAvailableVehiclesController(IMediator mediator, ListAvailableVehiclesPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>Lists all vehicles currently available for renting.</summary>
        /// <returns>A list of available vehicles.</returns>
        [HttpGet("available")]
        public async Task<IActionResult> ListAvailable()
        {
            await _mediator.Send(new ListAvailableVehiclesInput());
            return _presenter.ActionResult;
        }
    }
}
