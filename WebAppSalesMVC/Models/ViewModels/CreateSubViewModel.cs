using System.Collections.Generic;

namespace WebAppSalesMVC.Models.ViewModels
{
    public class CreateSubViewModel
    {
        public Subsidiary Subsidiary { get; set; }
        public ICollection<State> States { get; set; }
    }
}