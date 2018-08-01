using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.DataObjectLayer.Models;

namespace PropertyManagement.DataObjectLayer
{
    public interface IRepairRepository
    {
        Task<List<RepairList>> RepairList(int PropertyId);
        Task<Repair> RepairById(int RepairId);
        Task SaveRepairData(int RepairId, int PropertyId, int UrgencyId, int RequestTypeId, int ServiceCategoryId, int ProfessionalServiceId, string Description,
                                                       string RepairReportedDate, string RepairCompletedDate, string TechnicianName, string RepairCost, int PaymentTypeId, string Notes, int StatusId);
    }
}
