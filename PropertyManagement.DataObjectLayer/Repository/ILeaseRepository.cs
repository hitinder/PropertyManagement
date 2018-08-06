using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.DataObjectLayer.Models;


namespace PropertyManagement.DataObjectLayer
{
   public interface ILeaseRepository
    {
        Task<List<LeaseList>> LeaseList(int Year, int Month); 
        Task<List<PropertiesForLease>> PropertiesForLease();
        Task<Lease> LeaseById(int LeaseId);
        Task LeaseAdd(int PropertyId, int TenantId, string LeaseBeginDate, string LeaseEndDate, decimal MonthlyLease, decimal ProratedAmount, string ProratedFromDate, string ProratedToDate, string Notes, int StatusId);
        Task LeaseUpdate(int LeaseId, int PropertyId, int TenantId, string LeaseBeginDate, string LeaseEndDate, decimal MonthlyLease, decimal ProratedAmount, string ProratedFromDate, string ProratedToDate, string Notes, int StatusId);
        Task SaveSelectedProperties(int Year, string PropertyIds);
    }
}
