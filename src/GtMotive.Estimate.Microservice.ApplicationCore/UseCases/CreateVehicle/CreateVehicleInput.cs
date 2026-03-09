using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Input data for the CreateVehicle use case.
    /// </summary>
    public sealed class CreateVehicleInput : IUseCaseInput, IRequest<Unit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="licensePlate">Vehicle license plate.</param>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="model">Vehicle model.</param>
        /// <param name="manufacturingDate">Date of manufacture.</param>
        public CreateVehicleInput(string licensePlate, string brand, string model, DateTime manufacturingDate)
        {
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
        }

        /// <summary>Gets the license plate.</summary>
        public string LicensePlate { get; }

        /// <summary>Gets the brand.</summary>
        public string Brand { get; }

        /// <summary>Gets the model.</summary>
        public string Model { get; }

        /// <summary>Gets the manufacturing date.</summary>
        public DateTime ManufacturingDate { get; }
    }
}
