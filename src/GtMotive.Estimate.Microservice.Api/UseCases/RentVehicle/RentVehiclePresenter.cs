using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    /// <summary>
    /// Web API presenter for the RentVehicle use case.
    /// </summary>
    public sealed class RentVehiclePresenter : IRentVehicleOutputPort, IWebApiPresenter
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(StatusCodes.Status500InternalServerError);

        /// <inheritdoc/>
        public void StandardHandle(RentVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);
            ActionResult = new OkObjectResult(response);
        }

        /// <inheritdoc/>
        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Not Found",
                Detail = message,
            });
        }
    }
}
