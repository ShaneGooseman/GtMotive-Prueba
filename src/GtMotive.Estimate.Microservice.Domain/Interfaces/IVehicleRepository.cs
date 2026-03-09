#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Output port for vehicle persistence operations.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>Gets a vehicle by its identifier.</summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>The vehicle if found, or null.</returns>
        Task<Vehicle?> GetByIdAsync(Guid vehicleId);

        /// <summary>Gets all available vehicles.</summary>
        /// <returns>A read-only collection of available vehicles.</returns>
        Task<IReadOnlyCollection<Vehicle>> GetAvailableAsync();

        /// <summary>Gets the vehicle currently rented by the specified customer.</summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>The rented vehicle if found, or null.</returns>
        Task<Vehicle?> GetRentedByCustomerAsync(string customerId);

        /// <summary>Adds a new vehicle to the repository.</summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(Vehicle vehicle);

        /// <summary>Persists changes to an existing vehicle.</summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Vehicle vehicle);
    }
}
