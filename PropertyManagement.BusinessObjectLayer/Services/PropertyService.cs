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
    public class PropertyService: IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;

        }

        public async Task<List<PropertyViewModel>> PropertyList()
        {
            List<PropertyList> property = await _propertyRepository.PropertyList();

            List<PropertyViewModel> propertyVM = new List<PropertyViewModel>();
            foreach (PropertyList p in property)
            {
                PropertyViewModel pVM = new PropertyViewModel();
                pVM.PropertyId = p.PropertyId;
                pVM.PropertyTypeName = p.PropertyTypeName;
                pVM.Address = p.Address;
                pVM.UnitNumber = p.UnitNumber;
                pVM.City = p.City;
                pVM.State = p.State;
                pVM.ZipCode = p.ZipCode;
                pVM.StatusName = p.StatusName;
                pVM.PurchaseDate = p.PurchaseDate;
                pVM.SoldDate = p.SoldDate;
                pVM.Notes = p.Notes;
                pVM.FullAddress = p.FullAddress;

                propertyVM.Add(pVM);
            }

            return propertyVM;
        }

        public List<PropertyViewModel> PropertyList(int PropertyStatusId)
        {
            List<PropertyList> property =  _propertyRepository.PropertyList(PropertyStatusId);

            List<PropertyViewModel> propertyVM = new List<PropertyViewModel>();
            foreach (PropertyList p in property)
            {
                PropertyViewModel pVM = new PropertyViewModel();
                pVM.PropertyId = p.PropertyId;
                pVM.FullAddress = p.FullAddress;
                propertyVM.Add(pVM);
            }

            return propertyVM;
        }

        public List<PropertyViewModel> PropertyListForLease()
        {
            List<PropertyList> property = _propertyRepository.PropertyListForLease();

            List<PropertyViewModel> propertyVM = new List<PropertyViewModel>();
            foreach (PropertyList p in property)
            {
                PropertyViewModel pVM = new PropertyViewModel();
                pVM.PropertyId = p.PropertyId;
                pVM.FullAddress = p.FullAddress;
                propertyVM.Add(pVM);
            }

            return propertyVM;
        }
        

        public async Task<PropertyViewModel> PropertyById(int PropertyId)
        {
            var p = await _propertyRepository.PropertyById(PropertyId);

            PropertyViewModel pVM = new PropertyViewModel();
            pVM.PropertyId = p.PropertyId;
            pVM.PropertyTypeId = p.PropertyTypeId;
            pVM.Address = p.Address;
            pVM.UnitNumber = p.UnitNumber;
            pVM.City = p.City;
            pVM.StateId = p.StateId;
            pVM.ZipCode = p.ZipCode;
            pVM.StatusId = p.StatusId;
            pVM.PurchaseDate = p.PurchaseDate;
            pVM.PurchasePrice = p.PurchasePrice;
            pVM.SoldPrice = p.SoldPrice;
            pVM.SoldDate = p.SoldDate;
            pVM.Notes = p.Notes;
            pVM.FullAddress = p.FullAddress;
            return pVM;
        }

        public async Task SavePropertyData(int PropertyId, int PropertyTypeId, string Address, string UnitNumber, string City, int StateId, string ZipCode, string PurchasePrice, string PurchaseDate, string SoldPrice, string SoldDate, string Notes, int StatusId)
        {
            await _propertyRepository.SavePropertyData(PropertyId, PropertyTypeId, Address, UnitNumber, City, StateId, ZipCode, PurchasePrice, PurchaseDate, SoldPrice, SoldDate, Notes, StatusId);
        }


    }
}
