using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.BusinessObjectLayer.ViewModels;


namespace PropertyManagement.BusinessObjectLayer
{
    public interface ITenantService
    {
        Task<List<TenantViewModel>> TenantList();

        Task<TenantViewModel> TenantById(int TenantId);

        Task SaveTenantData(int TenantId, string FirstName, string LastName, string DOB, int Age, string Gender, string DriverLicenseNo, string Phone, string Email,
                                              string EmergencyContact, int PropertyId, string MoveInDate, string MoveOutDate, decimal MonthlyRent, decimal DepositAmount,
                                              decimal DepositReturned, decimal DepositWithHold, string Notes, decimal ProratedRent, int StatusId);
    }
}
