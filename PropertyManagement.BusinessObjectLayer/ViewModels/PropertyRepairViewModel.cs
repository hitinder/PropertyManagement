using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyManagement.BusinessObjectLayer.ViewModels
{
    public class PropertyRepairViewModel
    {
        public PropertyViewModel PropertyVM {get;set;}
        public List<RepairViewModel> RepairVM { get; set; }
    }
}
