using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    /// <summary>
    /// Web API presenter for the ReturnVehicle use case.
    /// </summary>
    public sealed class ReturnVehiclePresenter : IReturnVehicleOutputPort, IWebApiPresenter
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(StatusCodes.Status500InternalServerError);

        /// <inheritdoc/>
        public void StandardHandle(ReturnVehicleOutput response)
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
