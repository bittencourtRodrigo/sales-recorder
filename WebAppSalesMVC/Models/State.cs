using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppSalesMVC.Models
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "State name")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Subsidiary> Subsidiaries { get; set; } = new List<Subsidiary>();

        public State()
        {
        }

        public State(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void NewSubsidiary(Subsidiary subsidiary)
        {
            Subsidiaries.Add(subsidiary);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Subsidiaries.Sum(sb => sb.TotalSales(initial, final));
        }
    }
}