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

        public LeaseController(ILeaseService leaseService, IPropertyService propertyService, IStatusService statusService, IRepairService repairService, ICommonListService commonListService)
        {
            _leaseService = leaseService;
            _propertyService = propertyService;
            _statusService = statusService;
            _commonListService = commonListService;
        }

        public async Task<IActionResult> Index(int Year = 0, int Month = 0)
        {
            int _year = DateTime.Now.Year;
            int _month = DateTime.Now.Month;
            if (Year == 0)
                Year = _year;
            if (Month == 0)
                Month = _month;

            var years =  _commonListService.YearList();
            var selectedYear = DateTime.Now.Year;
            SelectList ListYears = new SelectList(years, "Year", "Year", selectedYear);         
            ViewBag.Years = ListYears;
            ViewBag.Months =  _commonListService.MonthList();

            var query = await _leaseService.LeaseList(Year, Month);
            return View(query);
        }

        public async Task<IActionResult> AddProperties()
        {
            var query = await _leaseService.PropertiesForLease();
            return PartialView(query);
        }
    }
}