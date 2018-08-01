using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.BusinessObjectLayer;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace PropertyManagement.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly ITenantService _tenantService;

        public VehicleController(IVehicleService vehicleService, ITenantService tenantService)
        {
            _vehicleService = vehicleService;
            _tenantService = tenantService;
        }

        public async Task<IActionResult> Index(int TenantId = 0)
        {
            var query = await _vehicleService.VehicleList(TenantId);
            var tenant = await _tenantService.TenantById(TenantId);

            ViewBag.TenantId = TenantId;
            ViewBag.TenantInformation = tenant.LastName + ", " + tenant.FirstName;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEditVehicle(int VehicleId = 0, int TenantId = 0)
        {
            try
            {
                if (VehicleId > 0)
                {
                    var query = await this._vehicleService.VehicleById(VehicleId);

                    ViewBag.TableTitle = "Edit Vehicle Information";
                    return View(query);
                }
                else
                {
                    ViewBag.TableTitle = "Add Vehicle Information";
                    return View();
                }

            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEditVehicle(int VehicleId, int TenantId, string Make, string Model, int Year, string LicensePlate, string StateRegistration, string Color, string Notes)
        {
            try
            {
                await this._vehicleService.SaveVehicleData(VehicleId, TenantId, Make, Model, Year, LicensePlate, StateRegistration, Color, Notes);
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
    }
}