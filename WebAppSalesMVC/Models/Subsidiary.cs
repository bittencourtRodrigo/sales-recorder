﻿using System;
using System.Collections.Generic;

namespace WebAppSalesMVC.Models
{
    public class Subsidiary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Opening { get; set; }
        public double FixedCost { get; set; }
        public State State { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();
    }
}
