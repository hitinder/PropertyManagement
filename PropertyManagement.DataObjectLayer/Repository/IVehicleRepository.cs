using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.DataObjectLayer.Models;

namespace PropertyManagement.DataObjectLayer
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> VehicleList(int TenantId);
        Task<Vehicle> VehicleById(int VehicleId);
        Task SaveVehicleData(int VehicleId, int TenantId, string Make, string Model, int Year, string LicensePlate, string StateRegistration, string Color, string Notes);
    }
}
