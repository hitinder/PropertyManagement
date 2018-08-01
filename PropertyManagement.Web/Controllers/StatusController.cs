using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.BusinessObjectLayer;
using System.Data.SqlClient;

namespace PropertyManagement.Web.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        public async Task<IActionResult> Index()
        {
            var query = await _statusService.StatusList();
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int StatusId = 0)
        {
            if (StatusId > 0)
            {
                var query = await this._statusService.StatusById(StatusId);
                ViewBag.StatusTitle = "Edit Status";
                return View(query);
            }
            else
            {
                ViewBag.StatusTitle = "Add Status";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(int StatusId, string StatusName, int StatusType )
        {
            try
            {
                    await this._statusService.SaveStatusData(StatusName, StatusId, StatusType);
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

    }
}