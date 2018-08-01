using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using PropertyManagement.DataObjectLayer;
using PropertyManagement.DataObjectLayer.Models;
using System.Threading.Tasks;

namespace PropertyManagement.BusinessObjectLayer
{
    public class RepairService: IRepairService
    {
        private readonly IRepairRepository _repairRepository;

        public RepairService(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;

        }
        public async Task<List<RepairViewModel>> RepairList(int PropertyId)
        {
            List<RepairList> repair = await _repairRepository.RepairList(PropertyId);

            List<RepairViewModel> repairVM = new List<RepairViewModel>();
            foreach (RepairList r in repair)
            {
                RepairViewModel rVM = new RepairViewModel();
                rVM.PropertyId = r.PropertyId;
                rVM.UrgencyName = r.UrgencyName;
                rVM.RequestTypeName  = r.RequestTypeName;
                rVM.RepairId = r.RepairId;
                rVM.ServiceCategoryName = r.ServiceCategoryName;
                rVM.Description = r.Description;
                rVM.RepairReportedDate = r.RepairReportedDate;
                rVM.RepairCompletedDate = r.RepairCompletedDate;
                rVM.TechnicianName = r.TechnicianName;
                rVM.RepairCost = Convert.ToDecimal(string.Format("{0:0.00}", r.RepairCost));
                rVM.Notes = r.Notes;
                rVM.StatusName = r.StatusName;
                rVM.PaymentTypeName = r.PaymentTypeName;
                rVM.RepairId = r.RepairId;
                repairVM.Add(rVM);
            }

            return repairVM;
        }

        public async Task<RepairViewModel> RepairById(int RepairId)
        {
            var r = await _repairRepository.RepairById(RepairId);

            RepairViewModel rVM = new RepairViewModel();
            rVM.RepairId = r.RepairId;
            rVM.PropertyId = r.PropertyId;
            rVM.UrgencyId = r.UrgencyId;
            rVM.RequestTypeId = r.RequestTypeId;
            rVM.ServiceCategoryId = r.ServiceCategoryId;
            rVM.ProfessionalServiceId = r.ProfessionalServiceId;
            rVM.Description = r.Description;
            rVM.RepairReportedDate = r.RepairReportedDate;
            rVM.RepairCompletedDate = r.RepairCompletedDate;
            rVM.TechnicianName = r.TechnicianName;
            rVM.RepairCost = r.RepairCost;
            rVM.PaymentTypeId = r.PaymentTypeId;           
            rVM.Notes = r.Notes;
            rVM.StatusId = r.StatusId;
            return rVM;
        }

        public async Task SaveRepairData(int RepairId, int PropertyId, int UrgencyId, int RequestTypeId, int ServiceCategoryId, int ProfessionalServiceId, string Description,
                                                       string RepairReportedDate, string RepairCompletedDate, string TechnicianName, string RepairCost, int PaymentTypeId, string Notes, int StatusId)
        {
            await _repairRepository.SaveRepairData(RepairId, PropertyId, UrgencyId, RequestTypeId, ServiceCategoryId, ProfessionalServiceId, Description,
                                                       RepairReportedDate, RepairCompletedDate, TechnicianName, RepairCost, PaymentTypeId, Notes, StatusId);
        }

    }
}
