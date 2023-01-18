using System;
using System.Collections.Generic;
using System.Linq;
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

        public Subsidiary()
        {
        }

        public Subsidiary(int id, string name, string email, DateTime opening, double fixedCost, State state)
        {
            Id = id;
            Name = name;
            Email = email;
            Opening = opening;
            FixedCost = fixedCost;
            State = state;
        }

        public void AddSaleRecord(SalesRecord salesRecord)
        {
            SalesRecords.Add(salesRecord);
        }

        public void RemoveSaleRecord(SalesRecord salesRecord)
        {
            SalesRecords.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
