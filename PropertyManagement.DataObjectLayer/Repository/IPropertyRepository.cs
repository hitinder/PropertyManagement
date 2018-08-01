using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.DataObjectLayer.Models;

namespace PropertyManagement.DataObjectLayer
{
    public interface IPropertyRepository
    {
        Task<List<PropertyList>> PropertyList();
        List<PropertyList> PropertyList(int PropertyStatusId);
        List<PropertyList> PropertyListForLease();       
        Task<Property> PropertyById(int PropertyId);
        Task SavePropertyData(int PropertyId, int PropertyTypeId, string Address, string UnitNumber, string City, int StateId, string ZipCode, string PurchasePrice, string PurchaseDate, string SoldPrice, string SoldDate, string Notes, int StatusId);
    }
}
