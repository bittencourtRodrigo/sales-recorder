using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSalesMVC.Controllers
{
    public class SubsidiariesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
