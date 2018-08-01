using System;
using System.Collections.Generic;
using System.Text;
using PropertyManagement.DataObjectLayer;
using PropertyManagement.DataObjectLayer.Models;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using System.Threading.Tasks;

namespace PropertyManagement.BusinessObjectLayer
{
    public class VehicleService: IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;

        }

        public async Task<List<VehicleViewModel>> VehicleList(int TenantId)
        {
            List<Vehicle> vehicle = await _vehicleRepository.VehicleList(TenantId);

            List<VehicleViewModel> vehicleVM = new List<VehicleViewModel>();
            foreach (Vehicle v in vehicle)
            {
                VehicleViewModel vVM = new VehicleViewModel();
                vVM.VehicleId = v.VehicleId;
                vVM.TenantId = v.TenantId;
                vVM.Make = v.Make;
                vVM.Model = v.Model;
                vVM.Color = v.Color;
                vVM.Year = v.Year;
                vVM.LicensePlate = v.LicensePlate;
                vVM.StateRegistration = v.StateRegistration;
                vVM.Notes = v.Notes;
                vehicleVM.Add(vVM);
            }

            return vehicleVM;
        }


        public async Task<VehicleViewModel> VehicleById(int VehicleId)
        {
            var v = await _vehicleRepository.VehicleById(VehicleId);

            VehicleViewModel vVM = new VehicleViewModel();
            vVM.VehicleId = v.VehicleId;
            vVM.TenantId = v.TenantId;
            vVM.Make = v.Make;
            vVM.Model = v.Model;
            vVM.Color = v.Color;
            vVM.Year = v.Year;
            vVM.LicensePlate = v.LicensePlate;
            vVM.StateRegistration = v.StateRegistration;
            vVM.Notes = v.Notes;

            return vVM;
        }

        public async Task SaveVehicleData(int VehicleId, int TenantId, string Make, string Model, int Year, string LicensePlate, string StateRegistration, string Color, string Notes)
        {
            await _vehicleRepository.SaveVehicleData(VehicleId, TenantId, Make, Model, Year, LicensePlate, StateRegistration, Color, Notes); 
        }

    }
}
