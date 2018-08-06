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
    public class TenantService : ITenantService
    {      
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;

        }
        public async Task<List<TenantViewModel>> TenantList()
        {
            List<TenantList> tenant = await _tenantRepository.TenantList();

            List<TenantViewModel> tenantVM = new List<TenantViewModel>();
            foreach (TenantList t in tenant)
            {
                TenantViewModel tVM = new TenantViewModel();
                tVM.TenantId = t.TenantId;
                tVM.PropertyId = t.PropertyId;
                tVM.FirstName = t.FirstName;
                tVM.LastName = t.LastName;
                tVM.Age = t.Age;
                tVM.DOB = t.DOB;
                tVM.DriverLicenseNo = t.DriverLicenseNo;
                tVM.Email = t.Email;
                tVM.EmergencyContact = t.EmergencyContact;
                tVM.Gender = t.Gender;
                tVM.MoveInDate = t.MoveInDate;
                tVM.MoveOutDate = t.MoveOutDate;
                tVM.Phone = t.Phone;
                tVM.StatusId = t.StatusId;
                tVM.Notes = t.Notes;
                tVM.DepositAmount = t.DepositAmount;
                tVM.PropertyAddress = t.PropertyAddress;
                tVM.StatusName = t.StatusName;
                tVM.MonthlyRent = t.MonthlyRent;
                tVM.ProratedRent = t.ProratedRent;

                tenantVM.Add(tVM);
            }

            return tenantVM;
        }

        public List<TenantActiveListViewModel> TenantActive()
        {
            List<TenantActiveList> tenant =  _tenantRepository.TenantActive();

            List<TenantActiveListViewModel> tenantVM = new List<TenantActiveListViewModel>();
            foreach (TenantActiveList t in tenant)
            {
                TenantActiveListViewModel tVM = new TenantActiveListViewModel();
                tVM.TenantId = t.TenantId;
                tVM.FirstName = t.FirstName;
                tVM.LastName = t.LastName;
                tVM.FullName = t.FullName;
                tenantVM.Add(tVM);
            }

            return tenantVM;
        }


        public async Task<TenantViewModel> TenantById(int TenantId)
        {
            var t = await _tenantRepository.TenantById(TenantId);

            TenantViewModel tVM = new TenantViewModel();
            tVM.TenantId = t.TenantId;
            tVM.PropertyId = t.PropertyId;
            tVM.FirstName = t.FirstName;
            tVM.LastName = t.LastName;
            tVM.Age = t.Age;
            tVM.DOB = t.DOB;
            tVM.DriverLicenseNo = t.DriverLicenseNo;
            tVM.Email = t.Email;
            tVM.EmergencyContact = t.EmergencyContact;
            tVM.Gender = t.Gender;
            tVM.MoveInDate = t.MoveInDate;
            tVM.MoveOutDate = t.MoveOutDate;
            tVM.Phone = t.Phone;
            tVM.StatusId = t.StatusId;
            tVM.Notes = t.Notes;
            tVM.DepositAmount = Convert.ToDecimal(string.Format("{0:0.00}", t.DepositAmount));
            tVM.DepositReturned = Convert.ToDecimal(string.Format("{0:0.00}", t.DepositReturned));
            tVM.DepositWithHold = Convert.ToDecimal(string.Format("{0:0.00}", t.DepositWithHold));
            tVM.MonthlyRent = Convert.ToDecimal(string.Format("{0:0.00}", t.MonthlyRent));
            tVM.ProratedRent = Convert.ToDecimal(string.Format("{0:0.00}", t.ProratedRent));
            return tVM;
        }

        public async Task SaveTenantData(int TenantId, string FirstName, string LastName, string DOB, int Age, string Gender, string DriverLicenseNo, string Phone, string Email,
                                            string EmergencyContact, int PropertyId, string MoveInDate, string MoveOutDate, decimal MonthlyRent, decimal DepositAmount,
                                            decimal DepositReturned, decimal DepositWithHold, string Notes, decimal ProratedRent, int StatusId)
        {
            await _tenantRepository.SaveTenantData(TenantId, FirstName, LastName, DOB, Age, Gender, DriverLicenseNo, Phone, Email,
                                              EmergencyContact, PropertyId, MoveInDate, MoveOutDate, MonthlyRent, DepositAmount,
                                              DepositReturned, DepositWithHold, Notes, ProratedRent, StatusId);
        }


    }
}
