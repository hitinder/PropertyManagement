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
        Task LeaseUpdate(int LeaseId, int TenantId, decimal RentAmount, decimal AmountRecieved, string DateRecieved, decimal PastDue, decimal CurrentDue, decimal BalanceDue, string Notes);

        Task<List<PropertiesForLeaseViewModel>> PropertiesForLease();
        Task SaveSelectedProperties(int Year, string PropertyIds);
    }
}
