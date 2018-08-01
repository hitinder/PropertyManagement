using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.BusinessObjectLayer.ViewModels;

namespace PropertyManagement.BusinessObjectLayer
{
    public interface IVehicleService
    {
        Task<List<VehicleViewModel>> VehicleList(int TenantId);
        Task<VehicleViewModel> VehicleById(int VehicleId);
        Task SaveVehicleData(int VehicleId, int TenantId, string Make, string Model, int Year, string LicensePlate, string StateRegistration, string Color, string Notes);
    }
}
