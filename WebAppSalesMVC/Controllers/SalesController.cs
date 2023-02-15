using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Models;
using WebAppSalesMVC.Models.ViewModels;
using WebAppSalesMVC.Services;
namespace WebAppSalesMVC.Controllers
{
    public class SalesController : Controller
    {
        readonly StateService _stateService;
        readonly SubsidiaryService _subsidiaryService;
        readonly SalesRecordService _salesRecordService;

        public SalesController(StateService stateService, SubsidiaryService subsidiaryService, SalesRecordService salesRecordService)
        {
            _stateService = stateService;
            _subsidiaryService = subsidiaryService;
            _salesRecordService = salesRecordService;
        }

        public IActionResult SalesRecords()
        {
            return View();
        }

        public async Task<IActionResult> GeneralSalesSearch(DateTime? dateMin, DateTime? dateMax)
        {
            if (!dateMax.HasValue)
            {
                dateMax = DateTime.Today;
            }
            if (!dateMin.HasValue)
            {
                dateMin = new DateTime(1, 1, 1);
            }
            ViewData["dateMin"] = dateMin.Value.ToString("yyyy-MM-dd");
            ViewData["dateMax"] = dateMax.Value.ToString("yyyy-MM-dd");
            var listSales = await _salesRecordService.GetSalesByDateAsync(dateMin, dateMax);
            return View(listSales);
        }

        public async Task<IActionResult> SalePerStateSearch(DateTime? dateMin, DateTime? dateMax)
        {
            if (!dateMax.HasValue)
            {
                dateMax = DateTime.Today;
            }
            if (!dateMin.HasValue)
            {
                dateMin = new DateTime(1, 1, 1);
            }
            ViewData["dateMin"] = dateMin.Value.ToString("yyyy-MM-dd");
            ViewData["dateMax"] = dateMax.Value.ToString("yyyy-MM-dd");
            var listSalesGroup = await _salesRecordService.GetSalesStatesByDateAsync(dateMin, dateMax);
            return View(listSalesGroup);
        }
        public async Task<IActionResult> Create(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var subsidiaries = await _subsidiaryService.GetSubByState(Id.Value);
            if (subsidiaries == null)
            {
                return NotFound();
            }
            var viewModel = new CreateSaleViewModel() { Subsidiaries = subsidiaries };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesRecord salesRecord)
        {
            _salesRecordService.CreateSale(salesRecord);
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Error(int id)
        {
            var error = new ErrorViewModel() { Message = id.ToString() };
            return View(error);
        }
    }

    
}
