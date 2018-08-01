using System;
using System.Collections.Generic;
using System.Text;
using PropertyManagement.DataObjectLayer;
using PropertyManagement.DataObjectLayer.Models;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using System.Threading.Tasks;

namespace PropertyManagement.BusinessObjectLayer
{
    public class DependentService: IDependentService
    {
        private readonly IDependentRepository _dependentRepository;

        public DependentService(IDependentRepository dependentRepository)
        {
            _dependentRepository = dependentRepository;

        }

        public async Task<List<DependentViewModel>> DependentList(int TenantId)
        {
            List<Dependent> dependent = await _dependentRepository.DependentList(TenantId);

            List<DependentViewModel> dependentVM = new List<DependentViewModel>();
            foreach (Dependent d in dependent)
            {
                DependentViewModel dVM = new DependentViewModel();
                dVM.DependentId = d.DependentId;
                dVM.TenantId = d.TenantId;
                dVM.FirstName = d.FirstName;
                dVM.LastName = d.LastName;
                dVM.Gender = d.Gender;
                dVM.Age = d.Age;
                dVM.Email = d.Email;
                dVM.Phone = d.Phone;
                dVM.Notes = d.Notes;
                dependentVM.Add(dVM);
            }

            return dependentVM;
        }


        public async Task<DependentViewModel> DependentById(int DependentId)
        {
            var d = await _dependentRepository.DependentById(DependentId);

            DependentViewModel dVM = new DependentViewModel();
            dVM.DependentId = d.DependentId;
            dVM.TenantId = d.TenantId;
            dVM.FirstName = d.FirstName;
            dVM.LastName = d.LastName;
            dVM.Gender = d.Gender;
            dVM.Age = d.Age;
            dVM.Email = d.Email;
            dVM.Phone = d.Phone;
            dVM.Notes = d.Notes;

            return dVM;
        }

        public async Task SaveDependentData(int DependentId, int TenantId, string FirstName, string LastName, string Gender, int Age, string Phone, string Email, string Notes)
        {
            await _dependentRepository.SaveDependentData(DependentId, TenantId, FirstName, LastName, Gender, Age, Phone, Email, Notes);
        }
    }
}
