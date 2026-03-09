#nullable enable
using System;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public sealed class CreateVehicleUseCaseTests
    {
        [Fact]
        public async Task Execute_WithValidVehicleData_CreatesVehicleAndReturnsOutput()
        {
            var repository = new InMemoryVehicleRepository();
            var outputPort = new TestCreateVehicleOutputPort();
            var useCase = new CreateVehicleUseCase(repository, outputPort);
            var input = new CreateVehicleInput("TEST-001", "Toyota", "Camry", DateTime.UtcNow.AddYears(-2));

            await useCase.Execute(input);

            outputPort.Output.Should().NotBeNull();
            outputPort.Output!.LicensePlate.Should().Be("TEST-001");
            outputPort.Output.Brand.Should().Be("Toyota");
            outputPort.Output.Id.Should().NotBe(Guid.Empty);

            var available = await repository.GetAvailableAsync();
            available.Should().HaveCount(1);
        }

        [Fact]
        public async Task Execute_WithManufacturingDateOlderThan5Years_DoesNotCreateVehicle()
        {
            var repository = new InMemoryVehicleRepository();
            var outputPort = new TestCreateVehicleOutputPort();
            var useCase = new CreateVehicleUseCase(repository, outputPort);
            var input = new CreateVehicleInput("TEST-002", "Ford", "Focus", DateTime.UtcNow.AddYears(-6));

            var act = () => useCase.Execute(input);

            await act.Should().ThrowAsync<GtMotive.Estimate.Microservice.Domain.DomainException>();
            var available = await repository.GetAvailableAsync();
            available.Should().BeEmpty();
        }

        private sealed class TestCreateVehicleOutputPort : ICreateVehicleOutputPort
        {
            public CreateVehicleOutput? Output { get; private set; }

            public void StandardHandle(CreateVehicleOutput response)
            {
                Output = response;
            }
        }
    }
}
