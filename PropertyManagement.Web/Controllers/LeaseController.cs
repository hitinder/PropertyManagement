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
    public class LeaseController : Controller
    {
        private readonly ILeaseService _leaseService;
        private readonly IPropertyService _propertyService;
        private readonly IStatusService _statusService;
        private readonly ICommonListService _commonListService;
        private readonly ITenantService _tenantService;

        
        

        public LeaseController(ILeaseService leaseService, IPropertyService propertyService, IStatusService statusService, IRepairService repairService, ICommonListService commonListService, ITenantService tenantService)
        {
            _leaseService = leaseService;
            _propertyService = propertyService;
            _statusService = statusService;
            _commonListService = commonListService;
            _tenantService = tenantService;
        }

        public async Task<IActionResult> Index(int Year = 0, int Month = 0)
        {

            if (Year == 0)
            {
                int _year = DateTime.Now.Year;
                Year = _year;
            }
            if (Month == 0)
            {
                int _month = DateTime.Now.Month;
                Month = _month;
            }

            var years =  _commonListService.YearList();
            var selectedYear = DateTime.Now.Year;
            SelectList ListYears = new SelectList(years, "Year", "Year", selectedYear);         
            ViewBag.Years = ListYears;
            ViewBag.Months =  _commonListService.MonthList();
            ViewBag.SelectedMonth = Month;
            ViewBag.SelectedYear = Year;

            var query = await _leaseService.LeaseList(Year, Month);
            return View(query);
        }

        public async Task<IActionResult> AddProperties()
        {
            var years = _commonListService.YearList();
            var selectedYear = DateTime.Now.Year;
            SelectList ListYears = new SelectList(years, "Year", "Year", selectedYear);
            ViewBag.Years = ListYears;
            var query = await _leaseService.PropertiesForLease();
            return PartialView(query);
        }

        [HttpPost]
        public async Task<IActionResult> SaveSelectedProperties(int Year, string PropertyIds)
        {
            try
            {
                PropertyIds = PropertyIds.Remove(PropertyIds.Length - 1, 1);

                await this._leaseService.SaveSelectedProperties(Year, PropertyIds);
            }
            catch (SqlException ex)
            {
                var errorMessage = ex.Message;
                return Content(errorMessage.ToString(), "text/plain");
            }
            return Content("");
        }
        [HttpGet]
        public async Task<IActionResult> EditLease(int LeaseId)
        {
            var Lease = await this._leaseService.LeaseById(LeaseId);
            TenantsDropDownList("TenantId", "FullName", Lease.TenantId);

            return PartialView(Lease);
        }

        public void TenantsDropDownList(string TenantId, string FullName, int TenantIdSel)
        {
            List<TenantActiveListViewModel> tenants = this._tenantService.TenantActive();

            var selectList = new SelectList(tenants, TenantId, FullName, TenantIdSel);
            ViewBag.Tenants = selectList;
        }

        [HttpPost]
        public async Task<IActionResult> SaveDataLease(int LeaseId, int TenantId, decimal RentAmount, decimal AmountRecieved, string DateReceived, decimal PastDue, decimal CurrentDue, decimal BalanceDue, string Notes)
        {
            try
            {
                await this._leaseService.LeaseUpdate(LeaseId, TenantId, RentAmount, AmountRecieved, DateReceived, PastDue, CurrentDue, BalanceDue, Notes);
            }
            catch (SqlException ex)
            {
                var errorMessage = ex.Message;
                return Content(errorMessage.ToString(), "text/plain");
            }
            return Content("");
        }
    }
}
