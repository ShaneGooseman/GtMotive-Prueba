using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    /// <summary>
    /// HTTP request model for renting a vehicle.
    /// </summary>
    public sealed class RentVehicleRequest
    {
        /// <summary>Gets or sets the customer identifier.</summary>
        [Required]
        public string CustomerId { get; set; } = string.Empty;
    }
}
