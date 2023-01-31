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
        public IActionResult Index()
        {
            var subsidiaries = _subsidiaryService.GetSubsidiaries();
            return View(subsidiaries);
        }

        public IActionResult Create()
        {
            var viewModel = new SubsidiaryFormViewModel { States = _stateService.GetStates() }; 
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subsidiary subsidiary)
        {
            if (!ModelState.IsValid)
            {
                var states = _stateService.GetStates();
                var formView = new SubsidiaryFormViewModel() { Subsidiary = subsidiary, States = states };
                return View(formView);
            }
            _subsidiaryService.AddNewSubsidiary(subsidiary);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });

            var obj = _subsidiaryService.GetById(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _subsidiaryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }

            var obj = _subsidiaryService.GetById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }
            List<State> states = _stateService.GetStates();
            SubsidiaryFormViewModel FormView = new SubsidiaryFormViewModel() { Subsidiary = obj, States = states };
            return View(FormView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Subsidiary subsidiary)
        {
            if (!ModelState.IsValid)
            {
                var states = _stateService.GetStates();
                var formView = new SubsidiaryFormViewModel() { Subsidiary = subsidiary, States = states };
                return View(formView);
            }

            if (id != subsidiary.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }

            try
            {
                _subsidiaryService.Update(subsidiary);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }
        }
        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error N. Report it." });
            }

            var subsidiary = _subsidiaryService.GetById(id.Value);
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

