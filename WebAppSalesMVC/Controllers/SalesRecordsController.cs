using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Services;

namespace WebAppSalesMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchSimpleByDate(DateTime? dateMin, DateTime? dateMax)
        {
            if (!dateMax.HasValue)
            {
                dateMax = DateTime.Today;
            }
            if (!dateMin.HasValue)
            {
                dateMin = new DateTime(1,1,1);
            }
            ViewData["dateMin"] = dateMin.Value.ToString("yyyy-MM-dd");
            ViewData["dateMax"] = dateMax.Value.ToString("yyyy-MM-dd");
            var listSales = await _salesRecordService.GetSalesByDateAsync(dateMin, dateMax);
            return View(listSales);
        } 

        public async Task<IActionResult> SearchGroupingByDate(DateTime? dateMin, DateTime? dateMax)
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
    }
}
