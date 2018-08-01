using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyManagement.BusinessObjectLayer.ViewModels
{
    public class DependentViewModel
    {
        public int DependentId { get; set; }
        public int TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
    }
}
