using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Handles returning of rented vehicles.
    /// </summary>
    [ApiController]
    [Route("api/vehicles")]
    public sealed class ReturnVehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ReturnVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleController"/> class.
        /// </summary>
        /// <param name="mediator">The MediatR mediator.</param>
        /// <param name="presenter">The output presenter.</param>
        public ReturnVehicleController(IMediator mediator, ReturnVehiclePresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>Returns a rented vehicle, making it available again.</summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>The updated vehicle information.</returns>
        [HttpPost("{vehicleId:guid}/return")]
        public async Task<IActionResult> Return(Guid vehicleId)
        {
            await _mediator.Send(new ReturnVehicleInput(vehicleId));
            return _presenter.ActionResult;
        }
    }
}
