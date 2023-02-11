using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Models;
using WebAppSalesMVC.Models.Enums;

namespace WebAppSalesMVC.Models.ViewModels
{
    public class CreateSaleViewModel
    {
        public ICollection<Subsidiary> Subsidiaries { get; set; }
        public SalesRecord SalesRecord { get; set; }
    }
}
