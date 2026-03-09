namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output port for the RentVehicle use case.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleOutput>, IOutputPortNotFound
    {
    }
}
