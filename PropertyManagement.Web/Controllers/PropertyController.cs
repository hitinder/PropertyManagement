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
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IStatusService _statusService;
        private readonly IRepairService _repairService;
        private readonly ICommonListService _commonListService;


        public PropertyController(IPropertyService propertyService, IStatusService statusService, IRepairService repairService, ICommonListService commonListService)
        {
            _propertyService = propertyService;
            _statusService = statusService;
            _repairService = repairService;
            _commonListService = commonListService;
        }

        public IActionResult TabView(string PropertyId, string TabId)
        {
            string tabName = "";
            ViewBag.PropertyId = PropertyId;
            ViewBag.TabId = TabId;

            if (TabId == "1")
                tabName = "Edit";
            else 
                tabName = "RepairList";
            ViewBag.TabName = tabName;
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var query = await _propertyService.PropertyList();
            return View(query);
        }

        [HttpGet]
        public ActionResult Create()
        {
            PropertyTypeDropDownList("PropertyTypeId", "PropertyTypeName", 0);
            StatesDropDownList("StateId", "StateName", 0);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int PropertyTypeId, string Address, string UnitNumber, string City, int StateId, string ZipCode, string PurchasePrice, string PurchaseDate, string SoldPrice, string SoldDate, string Notes)
        {
            try
            {
                int StatusId = 0;
                int PropertyId = 0;
                await this._propertyService.SavePropertyData(PropertyId, PropertyTypeId, Address, UnitNumber, City, StateId, ZipCode, PurchasePrice, PurchaseDate, SoldPrice, SoldDate, Notes, StatusId);
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int PropertyId)
        {
            int StatusTypeId = 0;
            var editProperty = await this._propertyService.PropertyById(PropertyId);
            PropertyTypeDropDownList("PropertyTypeId", "PropertyTypeName", editProperty.PropertyTypeId);
            StatusDropDownList("StatusId", "StatusName", editProperty.StatusId, StatusTypeId);
            StatesDropDownList("StateId", "StateName", editProperty.StateId);
            ViewBag.PropertyAddress = editProperty.FullAddress;
            ViewBag.PropertyId = PropertyId;

            return PartialView(editProperty);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int PropertyId, int PropertyTypeId, string Address, string UnitNumber, string City, int StateId, string ZipCode, string PurchasePrice, string PurchaseDate, string SoldPrice, string SoldDate, string Notes, int StatusId)
        {
            try
            {
                await this._propertyService.SavePropertyData(PropertyId, PropertyTypeId, Address, UnitNumber, City, StateId, ZipCode, PurchasePrice, PurchaseDate, SoldPrice, SoldDate, Notes, StatusId);
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            PropertyTypeDropDownList("PropertyTypeId", "PropertyTypeName", PropertyTypeId);
            StatusDropDownList("StatusId", "StatusName", StatusId, 0);
            StatesDropDownList("StateId", "StateName", StateId);
            return View();
        }

        //Status
        public void StatusDropDownList(string statusId, string statusName, int ItemId, int StatusTypeId)
        {
             List<StatusViewModel> status = this._statusService.StatusList(StatusTypeId);

           var selectList = new SelectList(status, statusId, statusName, ItemId);
            ViewBag.Status = selectList;
        }

        //States
        public void StatesDropDownList(string StateId, string StateCode, int ItemId)
        {

            List<StatesViewModel> states = this._commonListService.StatesList();

            var selectList = new SelectList(states, StateId, StateCode, ItemId);
            ViewBag.States = selectList;
        }

        //Property Type
        public void PropertyTypeDropDownList(string PropertyTypeId, string PropertyTypeName, int ItemId)
        {

            List<PropertyTypeViewModel> propertytypes = this._commonListService.PropertyTypeList();

            var selectList = new SelectList(propertytypes, PropertyTypeId, PropertyTypeName, ItemId);
            ViewBag.PropertyTypes = selectList;
        }

        /***************************************************************** REPAIR SECTION ************************************************/

        public async Task<IActionResult> RepairList(int PropertyId)
        {
            @ViewBag.PropertyId = PropertyId;
            var property = await this._propertyService.PropertyById(PropertyId);
            ViewBag.PropertyInformation = property.FullAddress;

            var query = await _repairService.RepairList(PropertyId);
  
            return PartialView(query);
        }



        [HttpGet]
        public async Task<IActionResult> AddEditRepair(int RepairId = 0, int PropertyId = 0)
        {
            try
            {
                var property = await this._propertyService.PropertyById(PropertyId);
                ViewBag.PropertyInformation = property.Address + " - " + property.City;
                

                if (RepairId > 0)
                {
                    int StatusTypeId = 2;
                    var query = await this._repairService.RepairById(RepairId);
                    UrgencyTypeDropDownList("UrgencyId", "UrgencyName", query.UrgencyId);
                    ServiceCategoryTypeDropDownList("ServiceCategoryId", "ServiceCategoryName", query.ServiceCategoryId);
                    ProfessionalServiceTypeDropDownList("ProfessionalServiceId", "CompanyName", query.ProfessionalServiceId);
                    RequestTypeDropDownList("RequestTypeId", "RequestTypeName", query.RequestTypeId);
                    PaymentMethodTypeDropDownList("PaymentMethodId", "PaymentMethodName", query.PaymentTypeId);
                    StatusDropDownList("StatusId", "StatusName", query.StatusId, StatusTypeId);
                    ViewBag.TableTitle = "Edit Repair Information";
                    return PartialView(query);
                }
                else
                {
                    UrgencyTypeDropDownList("UrgencyId", "UrgencyName", 0);
                    ServiceCategoryTypeDropDownList("ServiceCategoryId", "ServiceCategoryName", 0);
                    ProfessionalServiceTypeDropDownList("ProfessionalServiceId", "CompanyName", 0);
                    RequestTypeDropDownList("RequestTypeId", "RequestTypeName", 0);
                    PaymentMethodTypeDropDownList("PaymentMethodId", "PaymentMethodName", 0);

                    ViewBag.TableTitle = "Add Repair Information";

                    RepairViewModel rVM = new RepairViewModel();
                    rVM.RepairId = RepairId;
                    rVM.PropertyId = PropertyId;
                    return PartialView(rVM);
                }
                    
            }
            catch (SqlException ex)
            {
                var errorMessage = ex.Message;
                return Content(errorMessage.ToString(), "text/plain");
            }

        }

        [HttpPost]
        public async Task<IActionResult> SaveRepairData(int RepairId, int PropertyId, int UrgencyId, int RequestTypeId, int ServiceCategoryId, int ProfessionalServiceId, string Description,
                                                       string RepairReportedDate, string RepairCompletedDate, string TechnicianName, string RepairCost, int PaymentTypeId, string Notes, int StatusId)
        {
            try
            {
                await this._repairService.SaveRepairData(RepairId, PropertyId, UrgencyId, RequestTypeId, ServiceCategoryId, ProfessionalServiceId, Description,
                                                       RepairReportedDate, RepairCompletedDate, TechnicianName, RepairCost, PaymentTypeId, Notes, StatusId);
                //return RedirectToAction("TabView?PropertyId=" + PropertyId, 2);
            }
            catch (SqlException ex)
            {
                var errorMessage = ex.Message;
                return Content(errorMessage.ToString(), "text/plain");
            }
            return Content("");
        }
        //urgency
        public void UrgencyTypeDropDownList(string UrgencyId, string UrgencyName, int ItemId)
        {

            List<UrgencyTypeViewModel> urgency = this._commonListService.UrgencyList();

            var selectList = new SelectList(urgency, UrgencyId, UrgencyName, ItemId);
            ViewBag.UrgencyTypes = selectList;
        }
        //service category
        public void ServiceCategoryTypeDropDownList(string ServiceCategoryId, string ServiceCategoryName, int ItemId)
        {

            List<ServiceCategoryTypeViewModel> service = this._commonListService.ServiceCategoryList();

            var selectList = new SelectList(service, ServiceCategoryId, ServiceCategoryName, ItemId);
            ViewBag.ServiceCategoryTypes = selectList;
        }
        //professional service
        public void ProfessionalServiceTypeDropDownList(string ProfessionalServiceId, string CompanyName, int ItemId)
        {

            List<ProfessionalServiceTypeViewModel> professional = this._commonListService.ProfessionalServiceList();

            var selectList = new SelectList(professional, ProfessionalServiceId, CompanyName, ItemId);
            ViewBag.ProfessionalServiceTypes = selectList;
        }
        //request type
        public void RequestTypeDropDownList(string RequestTypeId, string RequestTypeName, int ItemId)
        {

            List<RequestTypeViewModel> request = this._commonListService.RequestTypeList();

            var selectList = new SelectList(request, RequestTypeId, RequestTypeName, ItemId);
            ViewBag.RequestTypes = selectList;
        }
        //payment method
        public void PaymentMethodTypeDropDownList(string PaymentMethodId, string PaymentMethodName, int ItemId)
        {

            List<PaymentMethodTypeViewModel> payment = this._commonListService.PaymentMethodList();

            var selectList = new SelectList(payment, PaymentMethodId, PaymentMethodName, ItemId);
            ViewBag.PaymentMethodTypes = selectList;
        }
    }
}