using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAppSalesMVC.Models;
using WebAppSalesMVC.Models.ViewModels;
using WebAppSalesMVC.Services;

namespace WebAppSalesMVC.Controllers
{
    public class SalesController : Controller
    {
        readonly SubsidiaryService _subsidiaryService;
        readonly SalesRecordService _salesRecordService;

        public SalesController(SubsidiaryService subsidiaryService, SalesRecordService salesRecordService)
        {
            _subsidiaryService = subsidiaryService;
            _salesRecordService = salesRecordService;
        }

        public IActionResult SalesRecords() // Initial page.
        {
            return View();
        }

        private void TreatDate(ref DateTime? dateMin, ref DateTime? dateMax) // Function to treat given date.
        {
            if (!dateMax.HasValue)
            {
                dateMax = new DateTime(9999, 12, 31);
            }
            if (!dateMin.HasValue)
            {
                dateMin = new DateTime(1, 1, 1);
            }
        }

        public async Task<IActionResult> GeneralSalesSearch(DateTime? dateMin, DateTime? dateMax)
        {
            TreatDate(ref dateMin, ref dateMax);
            var listSales = await _salesRecordService.GetSalesByDateAsync(dateMin, dateMax); // Queries the bank and filters according to the dates.
            ViewData["dateMin"] = dateMin.Value.ToString("yyyy-MM-dd"); // Uses this data in the View.
            ViewData["dateMax"] = dateMax.Value.ToString("yyyy-MM-dd"); // Uses this data in the View.
            return View(listSales);
        }

        public async Task<IActionResult> SalesPerStateSearch(DateTime? dateMin, DateTime? dateMax)
        {
            TreatDate(ref dateMin, ref dateMax);
            var listSalesGroup = await _salesRecordService.GetSalesStatesByDateAsync(dateMin, dateMax); // Queries the bank and filters according to the dates.
            ViewData["dateMin"] = dateMin.Value.ToString("yyyy-MM-dd"); // Uses this data in the View.
            ViewData["dateMax"] = dateMax.Value.ToString("yyyy-MM-dd"); // Uses this data in the View.
            return View(listSalesGroup);
        }

        public async Task<IActionResult> Create(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var subsidiaries = await _subsidiaryService.GetSubByState(Id.Value); // Returns the subsidiary that contains this id.
            if (subsidiaries == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 2. Report it." }); // Calls the error page passing the error message.
            }
            var viewModel = new CreateSaleViewModel() { Subsidiaries = subsidiaries }; // ViewModel instantiation.
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesRecord salesRecord)
        {
            if (salesRecord == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 3. Report it." }); // Calls the error page passing the error message.
            }
            _salesRecordService.CreateSale(salesRecord); //Create sale record.
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Error(string message) // Error page.
        {
            var error = new ErrorViewModel() { Message = message }; // ViewModel instantiation.
            return View(error);
        }
    }
}