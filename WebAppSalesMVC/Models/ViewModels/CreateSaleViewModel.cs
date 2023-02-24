using System.Collections.Generic;

namespace WebAppSalesMVC.Models.ViewModels
{
    public class CreateSaleViewModel
    {
        public ICollection<Subsidiary> Subsidiaries { get; set; }
        public SalesRecord SalesRecord { get; set; }
    }
}