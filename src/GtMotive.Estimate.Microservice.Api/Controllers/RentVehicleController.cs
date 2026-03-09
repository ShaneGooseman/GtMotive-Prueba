using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Handles renting of vehicles.
    /// </summary>
    [ApiController]
    [Route("api/vehicles")]
    public sealed class RentVehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly RentVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleController"/> class.
        /// </summary>
        /// <param name="mediator">The MediatR mediator.</param>
        /// <param name="presenter">The output presenter.</param>
        public RentVehicleController(IMediator mediator, RentVehiclePresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>Rents a vehicle to a customer.</summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="request">The rental request data.</param>
        /// <returns>The updated vehicle rental information.</returns>
        [HttpPost("{vehicleId:guid}/rent")]
        public async Task<IActionResult> Rent(Guid vehicleId, [FromBody] RentVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _mediator.Send(new RentVehicleInput(vehicleId, request.CustomerId));
            return _presenter.ActionResult;
        }
    }
}
