using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyManagement.BusinessObjectLayer.ViewModels
{
    public class RepairViewModel
    {
        public int RepairId { get; set; }
        public int PropertyId { get; set; }
        public int UrgencyId { get; set; }
        public string UrgencyName { get; set; }
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public int ProfessionalServiceId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string RepairReportedDate { get; set; }
        public string RepairCompletedDate { get; set; }
        public string TechnicianName { get; set; }
        public decimal RepairCost { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public string Notes { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
