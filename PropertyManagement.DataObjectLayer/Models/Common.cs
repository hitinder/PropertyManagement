using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyManagement.DataObjectLayer.Models
{
    public class States
    {
        [Key]
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }

    public class PropertyType
    {
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
    }

    public class UrgencyType
    {
        public int UrgencyId { get; set; }
        public string UrgencyName { get; set; }
    }

    public class ServiceCategoryType
    {
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
    }

    public class ProfessionalServiceType
    {
        public int ProfessionalServiceId { get; set; }
        public string CompanyName { get; set; }
    }

    public class RequestType
    {
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
    }

    public class PaymentMethodType
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
    }

    public class YearModel
    {
        public int YearId { get; set; }
        public int Year { get; set; }
    }

    public class MonthModel
    {
        public int MonthId { get; set; }
        public string Month { get; set; }
        public string MonthAbbr { get; set; }
    }
}
