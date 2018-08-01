using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyManagement.DataObjectLayer.Models
{
    public class Status
    {
        [Key]
        public int StatusId {get;set;}
        public string StatusName { get;set;}
        public int StatusType{ get; set; }
    }
}
