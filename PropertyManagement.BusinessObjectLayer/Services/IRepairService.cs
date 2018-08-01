using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.BusinessObjectLayer.ViewModels;

namespace PropertyManagement.BusinessObjectLayer
{
    public interface IRepairService
    {
        Task<List<RepairViewModel>> RepairList(int PropertyId);
        Task<RepairViewModel> RepairById(int RepairId);
        Task SaveRepairData(int RepairId, int PropertyId, int UrgencyId, int RequestTypeId, int ServiceCategoryId, int ProfessionalServiceId, string Description,
                                                       string RepairReportedDate, string RepairCompletedDate, string TechnicianName, string RepairCost, int PaymentTypeId, string Notes, int StatusId);
    }
}
