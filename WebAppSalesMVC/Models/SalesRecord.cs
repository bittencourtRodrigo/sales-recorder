using System;
using WebAppSalesMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebAppSalesMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        [Display(Name = "Date sale")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        public SaleStatus Status { get; set; }

        public Subsidiary Subsidiary { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Subsidiary")]
        public int SubsidiaryId { get; set; }

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