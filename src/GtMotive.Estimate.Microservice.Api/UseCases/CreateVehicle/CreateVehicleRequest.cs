using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// HTTP request model for creating a vehicle.
    /// </summary>
    public sealed class CreateVehicleRequest
    {
        /// <summary>Gets or sets the license plate.</summary>
        [Required]
        public string LicensePlate { get; set; } = string.Empty;

        /// <summary>Gets or sets the brand.</summary>
        [Required]
        public string Brand { get; set; } = string.Empty;

        /// <summary>Gets or sets the model.</summary>
        [Required]
        public string Model { get; set; } = string.Empty;

        /// <summary>Gets or sets the manufacturing date.</summary>
        [Required]
        public DateTime? ManufacturingDate { get; set; }
    }
}
