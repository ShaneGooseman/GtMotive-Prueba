using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public sealed class VehicleEndpointTests
    {
        private readonly GenericInfrastructureTestServerFixture _fixture;

        public VehicleEndpointTests(GenericInfrastructureTestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CreateVehicle_WithValidRequest_Returns201Created()
        {
            var client = _fixture.Server.CreateClient();
            var request = new CreateVehicleRequest
            {
                LicensePlate = "END-001",
                Brand = "BMW",
                Model = "3 Series",
                ManufacturingDate = DateTime.UtcNow.AddYears(-1),
            };

            var response = await client.PostAsJsonAsync(new Uri("/api/vehicles", UriKind.Relative), request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateVehicle_WithTooOldManufacturingDate_Returns400BadRequest()
        {
            var client = _fixture.Server.CreateClient();
            var request = new CreateVehicleRequest
            {
                LicensePlate = "END-003",
                Brand = "Old",
                Model = "Car",
                ManufacturingDate = DateTime.UtcNow.AddYears(-6),
            };

            var response = await client.PostAsJsonAsync(new Uri("/api/vehicles", UriKind.Relative), request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
