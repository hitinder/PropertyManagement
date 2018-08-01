using System;
using System.Collections.Generic;
using System.Text;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using PropertyManagement.DataObjectLayer;
using PropertyManagement.DataObjectLayer.Models;
using System.Threading.Tasks;

namespace PropertyManagement.BusinessObjectLayer
{
    public interface ICommonListService
    {
        List<StatesViewModel> StatesList();
        List<PropertyTypeViewModel> PropertyTypeList();
        List<UrgencyTypeViewModel> UrgencyList();
        List<ServiceCategoryTypeViewModel> ServiceCategoryList();
        List<ProfessionalServiceTypeViewModel> ProfessionalServiceList();
        List<RequestTypeViewModel> RequestTypeList();
        List<PaymentMethodTypeViewModel> PaymentMethodList();
        List<YearViewModel> YearList();
        List<MonthViewModel> MonthList();
    }
}
