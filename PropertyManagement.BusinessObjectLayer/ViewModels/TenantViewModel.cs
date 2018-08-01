using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyManagement.BusinessObjectLayer.ViewModels
{
    public class TenantViewModel
    {
        public int TenantId { get; set; }
        public int PropertyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string DriverLicenseNo { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string EmergencyContact { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public string MoveInDate { get; set; }
        public string MoveOutDate { get; set; }
        public int StatusId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DepositAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DepositReturned { get; set; }
        public string PropertyAddress { get; set; }
        public string StatusName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MonthlyRent { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ProratedRent { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DepositWithHold { get; set; }
    }
}
