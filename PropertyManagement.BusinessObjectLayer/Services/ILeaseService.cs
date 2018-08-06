using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.BusinessObjectLayer.ViewModels;

namespace PropertyManagement.BusinessObjectLayer
{
    public interface ILeaseService
    {
        Task<List<LeaseViewModel>> LeaseList(int Year, int Month);
        Task<LeaseViewModel> LeaseById(int LeaseId);
        Task LeaseAdd(int PropertyId, int TenantId, string LeaseBeginDate, string LeaseEndDate, decimal MonthlyLease, decimal ProratedAmount, string ProratedFromDate, string ProratedToDate, string Notes, int StatusId);
        Task LeaseUpdate(int LeaseId, int PropertyId, int TenantId, string LeaseBeginDate, string LeaseEndDate, decimal MonthlyLease, decimal ProratedAmount, string ProratedFromDate, string ProratedToDate, string Notes, int StatusId);

        Task<List<PropertiesForLeaseViewModel>> PropertiesForLease();
        Task SaveSelectedProperties(int Year, string PropertyIds);
    }
}
