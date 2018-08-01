﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyManagement.DataObjectLayer.Models
{
    public class Lease
    {
        [Key]
        public int LeaseId { get; set; }
        public int PropertyId { get; set; }
        public int TenantId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal RentAmount { get; set; }
        public decimal AmountReceived { get; set; }
        public string DateReceived { get; set; }
        public decimal PastDue { get; set; }
        public decimal CurrentDue { get; set; }
        public decimal BalanceDue { get; set; }
        public string Notes { get; set; }

    }

    public class LeaseList
    {
        public int LeaseId { get; set; }
        public int PropertyId { get; set; }
        public int TenantId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal RentAmount { get; set; }
        public decimal AmountReceived { get; set; }
        public string DateReceived { get; set; }
        public decimal PastDue { get; set; }
        public decimal CurrentDue { get; set; }
        public decimal BalanceDue { get; set; }
        public string Notes { get; set; }

    }

    public class PropertiesForLease
    {
        public int PropertyId { get; set; }
        public string PropertyAddress { get; set; }
    }
    }
