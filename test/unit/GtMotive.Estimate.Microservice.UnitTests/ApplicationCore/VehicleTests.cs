using System;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    public sealed class VehicleTests
    {
        [Fact]
        public void Constructor_WithValidData_CreatesAvailableVehicle()
        {
            var id = Guid.NewGuid();
            var manufacturingDate = DateTime.UtcNow.AddYears(-2);

            var vehicle = new Vehicle(id, "ABC-123", "Toyota", "Camry", manufacturingDate);

            vehicle.Id.Should().Be(id);
            vehicle.LicensePlate.Should().Be("ABC-123");
            vehicle.Brand.Should().Be("Toyota");
            vehicle.Model.Should().Be("Camry");
            vehicle.ManufacturingDate.Should().Be(manufacturingDate);
            vehicle.Status.Should().Be(VehicleStatus.Available);
            vehicle.CurrentCustomerId.Should().BeNull();
        }

        [Fact]
        public void Constructor_WithManufacturingDateOlderThan5Years_ThrowsDomainException()
        {
            var tooOldDate = DateTime.UtcNow.AddYears(-6);

            var act = () => new Vehicle(Guid.NewGuid(), "XYZ-789", "Ford", "Focus", tooOldDate);

            act.Should().Throw<DomainException>()
                .WithMessage("*5 years*");
        }

        [Fact]
        public void Constructor_WithEmptyLicensePlate_ThrowsDomainException()
        {
            var act = () => new Vehicle(Guid.NewGuid(), string.Empty, "Ford", "Focus", DateTime.UtcNow.AddYears(-1));

            act.Should().Throw<DomainException>()
                .WithMessage("*License plate*");
        }

        [Fact]
        public void Rent_AvailableVehicle_ChangesStatusToRented()
        {
            var vehicle = new Vehicle(Guid.NewGuid(), "ABC-123", "Toyota", "Camry", DateTime.UtcNow.AddYears(-2));

            vehicle.Rent("customer-001");

            vehicle.Status.Should().Be(VehicleStatus.Rented);
            vehicle.CurrentCustomerId.Should().Be("customer-001");
        }

        [Fact]
        public void Rent_AlreadyRentedVehicle_ThrowsDomainException()
        {
            var vehicle = new Vehicle(Guid.NewGuid(), "ABC-123", "Toyota", "Camry", DateTime.UtcNow.AddYears(-2));
            vehicle.Rent("customer-001");

            var act = () => vehicle.Rent("customer-002");

            act.Should().Throw<DomainException>()
                .WithMessage("*not available*");
        }

        [Fact]
        public void Return_RentedVehicle_ChangesStatusToAvailable()
        {
            var vehicle = new Vehicle(Guid.NewGuid(), "ABC-123", "Toyota", "Camry", DateTime.UtcNow.AddYears(-2));
            vehicle.Rent("customer-001");

            vehicle.Return();

            vehicle.Status.Should().Be(VehicleStatus.Available);
            vehicle.CurrentCustomerId.Should().BeNull();
        }

        [Fact]
        public void Return_AvailableVehicle_ThrowsDomainException()
        {
            var vehicle = new Vehicle(Guid.NewGuid(), "ABC-123", "Toyota", "Camry", DateTime.UtcNow.AddYears(-2));

            var act = () => vehicle.Return();

            act.Should().Throw<DomainException>()
                .WithMessage("*not currently rented*");
        }
    }
}
