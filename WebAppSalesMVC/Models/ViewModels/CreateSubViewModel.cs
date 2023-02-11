using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSalesMVC.Models.ViewModels
{
    public class CreateSubViewModel
    {
        public Subsidiary Subsidiary { get; set; }
        public ICollection<State> States { get; set; }
    }
}
