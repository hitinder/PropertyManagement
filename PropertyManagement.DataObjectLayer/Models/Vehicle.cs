using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyManagement.DataObjectLayer.Models
{
   public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public int TenantId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public string StateRegistration { get; set; }
        public string Color { get; set; }
        public string Notes { get; set; }
    }
}
