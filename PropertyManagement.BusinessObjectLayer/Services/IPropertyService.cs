using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.BusinessObjectLayer.ViewModels;

namespace PropertyManagement.BusinessObjectLayer
{
   public interface IPropertyService
    {
        Task<List<PropertyViewModel>> PropertyList();
        List<PropertyViewModel> PropertyList(int PropertyStatusId); 
        List<PropertyViewModel> PropertyListForLease();
        Task<PropertyViewModel> PropertyById(int PropertyId);
        Task SavePropertyData(int PropertyId, int PropertyTypeId, string Address, string UnitNumber, string City, int StateId, string ZipCode, string PurchasePrice, string PurchaseDate, string SoldPrice, string SoldDate, string Notes, int StatusId);
    }

}
