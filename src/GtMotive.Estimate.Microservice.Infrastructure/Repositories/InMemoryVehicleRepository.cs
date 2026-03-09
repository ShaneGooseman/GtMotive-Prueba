#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// In-memory implementation of <see cref="IVehicleRepository"/> for development and testing.
    /// </summary>
    public sealed class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = [];

        /// <inheritdoc/>
        public Task<Vehicle?> GetByIdAsync(Guid vehicleId)
        {
            return Task.FromResult(_vehicles.Find(v => v.Id == vehicleId));
        }

        /// <inheritdoc/>
        public Task<IReadOnlyCollection<Vehicle>> GetAvailableAsync()
        {
            IReadOnlyCollection<Vehicle> result = _vehicles
                .Where(v => v.Status == VehicleStatus.Available)
                .ToList()
                .AsReadOnly();

            return Task.FromResult(result);
        }

        /// <inheritdoc/>
        public Task<Vehicle?> GetRentedByCustomerAsync(string customerId)
        {
            return Task.FromResult(
                _vehicles.Find(v =>
                    v.Status == VehicleStatus.Rented &&
                    v.CurrentCustomerId == customerId));
        }

        /// <inheritdoc/>
        public Task AddAsync(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            _vehicles.Add(vehicle);
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task UpdateAsync(Vehicle vehicle)
        {
            // Entity is modified in place; no action required for in-memory storage.
            return Task.CompletedTask;
        }
    }
}
