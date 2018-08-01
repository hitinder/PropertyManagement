using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.DataObjectLayer.Models;

namespace PropertyManagement.DataObjectLayer
{
    public interface ICommonListRepository
    {
        List<States> StatesList();
        List<PropertyType> PropertyTypeList();
        List<UrgencyType> UrgencyList();
        List<ServiceCategoryType> ServiceCategoryList();
        List<ProfessionalServiceType> ProfessionalServiceList();
        List<RequestType> RequestTypeList();
        List<PaymentMethodType> PaymentMethodList();
        List<YearModel> YearList();
        List<MonthModel> MonthList();
    }
}
