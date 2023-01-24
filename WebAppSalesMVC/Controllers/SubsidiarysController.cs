using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Models;
using WebAppSalesMVC.Services;
using WebAppSalesMVC.Data;

namespace WebAppSalesMVC.Controllers
{
    public class SubsidiarysController : Controller
    {
        private readonly SubsidiaryService _subsidiaryService;

        public SubsidiarysController(SubsidiaryService subsidiaryService)
        {
            _subsidiaryService = subsidiaryService;
        }
        public IActionResult Index()
        {
            var subsidiaries = _subsidiaryService.GetSubsidiaries();
            return View(subsidiaries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subsidiary subsidiary)
        {
            _subsidiaryService.AddNewSubsidiary(subsidiary);
            return RedirectToAction(nameof(Index));
        }
    }
}

