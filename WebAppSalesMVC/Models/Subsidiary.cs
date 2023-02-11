using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace WebAppSalesMVC.Models
{
    public class Subsidiary
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [DataType(DataType.Date)]
        public DateTime Opening { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Fixed Cost")]
        [DataType(DataType.Currency)]
        public double FixedCost { get; set; }
            
        public State State { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "State")]
        public int StateId { get; set; } //foreign key incrementation
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
