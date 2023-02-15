using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Models.ViewModels;
using WebAppSalesMVC.Services;

namespace WebAppSalesMVC.Controllers
{
    public class HomeController : Controller
    {
        public readonly StateService _stateService;
        public HomeController(StateService stateService)
        {
            _stateService = stateService;
        }

        public async Task<IActionResult> Index()
        {   
            var states = await _stateService.GetStatesAsync();
            return View(states);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
