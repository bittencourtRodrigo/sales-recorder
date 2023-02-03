using System;
using System.Linq;  
using System.Collections.Generic;
namespace WebAppSalesMVC.Models
{
    public class State
    {
        public int Id { get; set; }
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
