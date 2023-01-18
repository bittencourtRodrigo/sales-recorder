using System;
using WebAppSalesMVC.Models.Enums;

namespace WebAppSalesMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Subsidiary Subsidiary { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Subsidiary subsidiary)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Subsidiary = subsidiary;
        }
    }
}
