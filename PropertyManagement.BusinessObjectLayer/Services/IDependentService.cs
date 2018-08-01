using System;
using System.Collections.Generic;
using System.Text;
using PropertyManagement.DataObjectLayer;
using PropertyManagement.DataObjectLayer.Models;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using System.Threading.Tasks;

namespace PropertyManagement.BusinessObjectLayer
{
    public interface IDependentService
    {
        Task<List<DependentViewModel>> DependentList(int TenantId);
        Task<DependentViewModel> DependentById(int DependentId);
        Task SaveDependentData(int DependentId, int TenantId, string FirstName, string LastName, string Gender, int Age, string Phone, string Email, string Notes);
    }
}
