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
   public class LeaseService : ILeaseService
    {
        private readonly ILeaseRepository _leaseRepository;

        public LeaseService(ILeaseRepository leaseRepository)
        {
            _leaseRepository = leaseRepository;

        }
        public async Task<List<LeaseViewModel>> LeaseList(int Year, int Month)
        {
            List<LeaseList> lease = await _leaseRepository.LeaseList(Year, Month);

            List<LeaseViewModel> leaseVM = new List<LeaseViewModel>();
            foreach (LeaseList l in lease)
            {
                LeaseViewModel lVM = new LeaseViewModel();
                lVM.LeaseId = l.LeaseId;
                lVM.PropertyId = l.PropertyId;
                lVM.TenantId = l.TenantId;
                lVM.Year = l.Year;
                lVM.Month = l.Month;
                lVM.RentAmount = l.RentAmount;
                lVM.AmountReceived = l.AmountReceived;
                lVM.DateReceived = l.DateReceived;
                lVM.PastDue = l.PastDue;
                lVM.CurrentDue = l.CurrentDue;
                lVM.BalanceDue = l.BalanceDue;
                lVM.Notes = l.Notes;

                leaseVM.Add(lVM);
            }

            return leaseVM;
        }
        public async Task<List<PropertiesForLeaseViewModel>> PropertiesForLease()
        {
            List<PropertiesForLease> lease = await _leaseRepository.PropertiesForLease();

            List<PropertiesForLeaseViewModel> leaseVM = new List<PropertiesForLeaseViewModel>();
            foreach (PropertiesForLease l in lease)
            {
                PropertiesForLeaseViewModel lVM = new PropertiesForLeaseViewModel();
                lVM.PropertyId = l.PropertyId;
                lVM.PropertyAddress = l.PropertyAddress;

                leaseVM.Add(lVM);
            }

            return leaseVM;
        }
        public async Task<LeaseViewModel> LeaseById(int LeaseId)
        {
            var l = await _leaseRepository.LeaseById(LeaseId);

            LeaseViewModel lVM = new LeaseViewModel();
            lVM.LeaseId = l.LeaseId;
            lVM.PropertyId = l.PropertyId;
            lVM.TenantId = l.TenantId;
            lVM.Year = l.Year;
            lVM.Month = l.Month;
            lVM.RentAmount = l.RentAmount;
            lVM.AmountReceived = l.AmountReceived;
            lVM.DateReceived = l.DateReceived;
            lVM.PastDue = l.PastDue;
            lVM.CurrentDue = l.CurrentDue;
            lVM.BalanceDue = l.BalanceDue;
            lVM.Notes = l.Notes;

            return lVM;
        }

        public async Task LeaseAdd(int PropertyId, int TenantId, string LeaseBeginDate, string LeaseEndDate, decimal MonthlyLease, decimal ProratedAmount, string ProratedFromDate, string ProratedToDate, string Notes, int StatusId)
        {
            await _leaseRepository.LeaseAdd(PropertyId, TenantId, LeaseBeginDate, LeaseEndDate, MonthlyLease, ProratedAmount, ProratedFromDate, ProratedToDate, Notes, StatusId);
        }

        public async Task LeaseUpdate(int LeaseId, int PropertyId, int TenantId, string LeaseBeginDate, string LeaseEndDate, decimal MonthlyLease, decimal ProratedAmount, string ProratedFromDate, string ProratedToDate, string Notes, int StatusId)
        {
            await _leaseRepository.LeaseUpdate(LeaseId, PropertyId, TenantId, LeaseBeginDate, LeaseEndDate, MonthlyLease, ProratedAmount, ProratedFromDate, ProratedToDate, Notes, StatusId);
        }
    }
}
