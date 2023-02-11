using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSalesMVC.Models;
using WebAppSalesMVC.Models.ViewModels;
using WebAppSalesMVC.Services;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Services.Exceptions;
using System.Diagnostics;

namespace WebAppSalesMVC.Controllers
{
    public class SubsidiarysController : Controller
    {
        private readonly SubsidiaryService _subsidiaryService;
        private readonly StateService _stateService;

        public SubsidiarysController(SubsidiaryService subsidiaryService, StateService stateService)
        {
            _subsidiaryService = subsidiaryService;
            _stateService = stateService;
        }
        public async Task<IActionResult> Index()
        {
            var subsidiaries = await _subsidiaryService.GetSubIncStateAsync();
            return View(subsidiaries);
        }

        public async Task<IActionResult> Create()
        {
            var states = await _stateService.GetStatesAsync();
            var viewModel = new CreateSubViewModel { States = states }; 
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subsidiary subsidiary)
        {
            if (!ModelState.IsValid)
            {
                var states = await _stateService.GetStatesAsync();
                var formView = new CreateSubViewModel() { Subsidiary = subsidiary, States = states };
                return View(formView);
            }
            
            await _subsidiaryService.AddNewSubsidiaryAsync(subsidiary);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });

            var subsidiary = await _subsidiaryService.GetByIdAsync(id.Value);
            if (subsidiary == null)
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });

            return View(subsidiary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _subsidiaryService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }

            var subsidiary = await _subsidiaryService.GetByIdAsync(id.Value);
            if (subsidiary == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }
            List<State> states = await _stateService.GetStatesAsync();
            var FormView = new CreateSubViewModel() { Subsidiary = subsidiary, States = states };
            return View(FormView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Subsidiary subsidiary)
        {
            if (!ModelState.IsValid)
            {
                var states = await _stateService.GetStatesAsync();
                var formView = new CreateSubViewModel() { Subsidiary = subsidiary, States = states };
                return View(formView);
            }

            if (id != subsidiary.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }

            try
            {
                await _subsidiaryService.UpdateAsync(subsidiary);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }

            var subsidiary = await _subsidiaryService.GetByIdAsync(id.Value);
            if (subsidiary == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }
            return View(subsidiary);
        }

        public IActionResult Error(string message)
        {
            var ViewError = new ErrorViewModel() { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(ViewError);
        }
    }
}

