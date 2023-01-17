using System.Collections.Generic;
namespace WebAppSalesMVC.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subsidiary> subsidiaries { get; set; } = new List<Subsidiary>();
    }
}
