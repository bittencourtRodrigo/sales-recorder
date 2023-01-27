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
            _subsidiaryService.AddNewSubsidiary(subsidiary);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            
            var obj = _subsidiaryService.GetById(id.Value);

            if (obj == null)
                return NotFound();

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
                return NotFound();
            }

            var obj = _subsidiaryService.GetById(id.Value);
            if (obj == null)
            {
                return BadRequest();
            }
            List<State> states = _stateService.GetStates();
            SubsidiaryFormViewModel subsidiaryFormView = new SubsidiaryFormViewModel() { Subsidiary = obj, States = states };
            return View(subsidiaryFormView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Subsidiary subsidiary)
        {
            if (id != subsidiary.Id)
            {
                return BadRequest();
            }

            try
            {
                _subsidiaryService.Update(subsidiary);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundExeption)
            {
                return NotFound();
            }
            catch(DbConcurrencyException)
            {
                return BadRequest();
            }
        } 
    }
}

