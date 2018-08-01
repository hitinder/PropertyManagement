using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.BusinessObjectLayer;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;


namespace PropertyManagement.Web.Controllers
{
    public class TenantController : Controller
    {
        private readonly ITenantService _tenantService;
        private readonly IPropertyService _propertyService;
        private readonly IStatusService _statusService;
        private readonly ICommonListService _commonListService;

        public TenantController(ITenantService tenantService, IPropertyService propertyService, IStatusService statusService, ICommonListService commonListService)
        {
            _tenantService = tenantService;
            _propertyService = propertyService;
            _statusService = statusService;
            _commonListService = commonListService;
        }

        public IActionResult TabView(string id)
        {
            ViewBag.TenantId = id;
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var query = await _tenantService.TenantList();
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEditTenant(int TenantId = 0)
        {           
            if (TenantId > 0)
            {
                var query = await this._tenantService.TenantById(TenantId);
                StatusDropDownList("StatusId", "StatusName", query.StatusId);
                PropertyDropDownListForLease("PropertyId", "FullAddress", query.PropertyId);
                return View(query);
            }
            else
            {
                TenantViewModel tVM = new TenantViewModel();
                tVM.TenantId = 0;
                PropertyDropDownListForLease("PropertyId", "FullAddress", 0);
                return View(tVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEditTenant(int TenantId, string FirstName, string LastName, string DOB, int Age, string Gender, string DriverLicenseNo, string Phone, string Email, 
                                              string EmergencyContact, int PropertyId, string MoveInDate, string MoveOutDate, decimal MonthlyRent, decimal DepositAmount, 
                                              decimal DepositReturned, decimal DepositWithHold, string Notes, decimal ProratedRent, int StatusId)
        {
            try
            {
                await this._tenantService.SaveTenantData(TenantId, FirstName, LastName, DOB, Age, Gender, DriverLicenseNo, Phone, Email,
                                              EmergencyContact, PropertyId, MoveInDate, MoveOutDate, MonthlyRent, DepositAmount,
                                              DepositReturned, DepositWithHold, Notes, ProratedRent, StatusId);
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        public void StatusDropDownList(string statusId, string statusName, int ItemId)
        {
            int StatusTypeId = 1;

            List<StatusViewModel> status = this._statusService.StatusList(StatusTypeId);

            var selectList = new SelectList(status, statusId, statusName, ItemId);
            ViewBag.Status = selectList;
        }
        
        public void PropertyDropDownList(string propertyId, string Address, int ItemId, int PropertyStatusId)
        {

            List <PropertyViewModel> property = this._propertyService.PropertyList(PropertyStatusId);

            var selectList = new SelectList(property, propertyId, Address, ItemId);
            ViewBag.Properties = selectList;
        }

        public void PropertyDropDownListForLease(string propertyId, string FullAddress, int ItemId)
        {
            List<PropertyViewModel> property = this._propertyService.PropertyListForLease();

            var selectList = new SelectList(property, propertyId, FullAddress, ItemId);
            ViewBag.PropertiesForLease = selectList;
        }

        // public async Task<IActionResult> Index()
        public IActionResult LeaseList(int TenantId)
        {
            return Content("Hi LeaseList Page");
        }
        public IActionResult DependentList(int TenantId)
        {
            return Content("Hi DependentList Page");
        }
        public IActionResult VehicleList(int TenantId)
        {
            return Content("Hi VehicleList Page");
        }
    }
}