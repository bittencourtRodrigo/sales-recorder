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

        public async Task<IActionResult> StateOfSale()
        {
            var states = await _stateService.GetStatesAsync();
            return View(states);
        }

        
        public async Task<IActionResult> Create(int? Id)
        {
            if (!Id.HasValue)
            {
                return RedirectToAction("Error", new { id = Id.Value });
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
        public ActionResult Create2(SalesRecord salesRecord)
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
