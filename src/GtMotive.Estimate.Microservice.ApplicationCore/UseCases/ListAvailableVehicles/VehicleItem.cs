using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Represents a vehicle item in the list response.
    /// </summary>
    public sealed class VehicleItem
    {
        /// <summary>Gets or sets the vehicle identifier.</summary>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the license plate.</summary>
        public string LicensePlate { get; set; } = string.Empty;

        /// <summary>Gets or sets the brand.</summary>
        public string Brand { get; set; } = string.Empty;

        /// <summary>Gets or sets the model.</summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>Gets or sets the manufacturing date.</summary>
        public DateTime ManufacturingDate { get; set; }

        /// <summary>Gets or sets the vehicle status.</summary>
        public VehicleStatus Status { get; set; }
    }
}
