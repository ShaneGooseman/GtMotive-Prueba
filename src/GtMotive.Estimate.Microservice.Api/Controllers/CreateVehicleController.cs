using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Handles the creation of vehicles in the fleet.
    /// </summary>
    [ApiController]
    [Route("api/vehicles")]
    public sealed class CreateVehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CreateVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleController"/> class.
        /// </summary>
        /// <param name="mediator">The MediatR mediator.</param>
        /// <param name="presenter">The output presenter.</param>
        public CreateVehicleController(IMediator mediator, CreateVehiclePresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>Creates a new vehicle in the fleet.</summary>
        /// <param name="request">The vehicle creation data.</param>
        /// <returns>The created vehicle.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (request.ManufacturingDate is null)
            {
                return BadRequest("ManufacturingDate is required.");
            }

            var input = new CreateVehicleInput(
                request.LicensePlate,
                request.Brand,
                request.Model,
                request.ManufacturingDate.Value);

            await _mediator.Send(input);
            return _presenter.ActionResult;
        }
    }
}
