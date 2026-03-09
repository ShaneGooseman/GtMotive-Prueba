using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Web API presenter for the ListAvailableVehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesPresenter : IListAvailableVehiclesOutputPort, IWebApiPresenter
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(StatusCodes.Status500InternalServerError);

        /// <inheritdoc/>
        public void StandardHandle(ListAvailableVehiclesOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);
            ActionResult = new OkObjectResult(response.Vehicles);
        }
    }
}
