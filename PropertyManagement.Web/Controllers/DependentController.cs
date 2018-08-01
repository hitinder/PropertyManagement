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
    public class DependentController : Controller
    {
        private readonly IDependentService _dependentService;
        private readonly ITenantService _tenantService;

        public DependentController(IDependentService dependentService, ITenantService tenantService)
        {
            _dependentService = dependentService;
            _tenantService = tenantService;
        }

        public async Task<IActionResult> Index(int TenantId = 0)
        {
            var query = await _dependentService.DependentList(TenantId);
            var tenant = await _tenantService.TenantById(TenantId);
            ViewBag.TenantId = TenantId;
            ViewBag.TenantInformation = tenant.LastName + ", " + tenant.FirstName;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEditDependent(int DependentId = 0, int TenantId = 0)
        {
            try
            {
                if (DependentId > 0)
                {
                    var query = await this._dependentService.DependentById(DependentId);

                    ViewBag.TableTitle = "Edit Dependent Information";
                    return View(query);
                }
                else
                {
                    ViewBag.TableTitle = "Add Dependent Information";
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
        public async Task<IActionResult> CreateEditDependent(int DependentId, int TenantId, string FirstName, string LastName, string Gender, int Age, string Phone, string Email, string Notes)
        {
            try
            {
                await this._dependentService.SaveDependentData(DependentId, TenantId, FirstName, LastName, Gender, Age, Phone, Email, Notes);
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