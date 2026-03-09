using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Web API presenter for the CreateVehicle use case.
    /// </summary>
    public sealed class CreateVehiclePresenter : ICreateVehicleOutputPort, IWebApiPresenter
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(StatusCodes.Status500InternalServerError);

        /// <inheritdoc/>
        public void StandardHandle(CreateVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);
            ActionResult = new CreatedResult(new Uri($"api/vehicles/{response.Id}", UriKind.Relative), response);
        }
    }
}
