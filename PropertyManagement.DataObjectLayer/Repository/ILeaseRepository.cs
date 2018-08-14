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
        Task LeaseUpdate(int LeaseId, int TenantId, decimal RentAmount, decimal AmountRecieved, string DateReceived, decimal PastDue, decimal CurrentDue, decimal BalanceDue, string Notes);
        Task SaveSelectedProperties(int Year, string PropertyIds);
    }
}
