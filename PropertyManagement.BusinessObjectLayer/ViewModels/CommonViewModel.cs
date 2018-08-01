using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyManagement.BusinessObjectLayer.ViewModels
{

    public class StatesViewModel
    {
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }

    public class PropertyTypeViewModel
    {
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
    }
    public class UrgencyTypeViewModel
    {
        public int UrgencyId { get; set; }
        public string UrgencyName { get; set; }
    }

    public class ServiceCategoryTypeViewModel
    {
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
    }

    public class ProfessionalServiceTypeViewModel
    {
        public int ProfessionalServiceId { get; set; }
        public string CompanyName { get; set; }
    }

    public class RequestTypeViewModel
    {
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
    }

    public class PaymentMethodTypeViewModel
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
    }

    public class YearViewModel
    {
        public int YearId { get; set; }
        public int Year { get; set; }
    }

    public class MonthViewModel
    {
        public int MonthId { get; set; }
        public string Month { get; set; }
        public string MonthAbbr { get; set; }
    }
}
