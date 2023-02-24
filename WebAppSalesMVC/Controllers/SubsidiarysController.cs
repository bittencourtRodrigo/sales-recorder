using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppSalesMVC.Models;
using WebAppSalesMVC.Models.ViewModels;
using WebAppSalesMVC.Services;
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

        public async Task<IActionResult> Index() // Initial page.
        {
            var subsidiaries = await _subsidiaryService.GetSubIncStateAsync(); // Returns a list of registered subsidiaries include her state.
            return View(subsidiaries);
        }

        public async Task<IActionResult> Create()
        {
            var states = await _stateService.GetStatesAsync(); // Returns a list of registered states for the select.
            var viewModel = new CreateSubViewModel { States = states }; // ViewModel instantiation.
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subsidiary subsidiary)
        {
            if (!ModelState.IsValid)
            {
                var states = await _stateService.GetStatesAsync(); // Returns a list of registered states for the select.
                var formView = new CreateSubViewModel() { Subsidiary = subsidiary, States = states }; // ViewModel instantiation.
                return View(formView);
            }
            await _subsidiaryService.AddNewSubsidiaryAsync(subsidiary);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Error 11. Report it." }); // Calls the error page passing the error message.

            var subsidiary = await _subsidiaryService.GetByIdAsync(id.Value); // Returns the subsidiary that contains this id.
            if (subsidiary == null)
                return RedirectToAction(nameof(Error), new { message = "Error 12. Report it." }); // Calls the error page passing the error message.

            return View(subsidiary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _subsidiaryService.RemoveAsync(id); // Function remove subsidiary for the id.
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 13. " + e.Message }); // Calls the error page passing the error message.
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 14. Report it." }); // Calls the error page passing the error message.
            }
            var subsidiary = await _subsidiaryService.GetByIdAsync(id.Value); // Returns the subsidiary that contains this id.
            if (subsidiary == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 15. Report it." }); // Calls the error page passing the error message.
            }
            List<State> states = await _stateService.GetStatesAsync(); // Returns a list of registered states for the select.
            var FormView = new CreateSubViewModel() { Subsidiary = subsidiary, States = states }; // ViewModel instantiation.
            return View(FormView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Subsidiary subsidiary)
        {
            if (!ModelState.IsValid)
            {
                var states = await _stateService.GetStatesAsync(); // Returns a list of registered states for the select.
                var formView = new CreateSubViewModel() { Subsidiary = subsidiary, States = states }; // ViewModel instantiation.
                return View(formView);
            }
            if (id != subsidiary.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 16. Report it." }); // Calls the error page passing the error message.
            }
            try
            {
                await _subsidiaryService.UpdateAsync(subsidiary);  // Function to update (to edit) subsidiary.
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 17. " + e.Message }); // Calls the error page passing the error message.
            }
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 18. Report it." }); // Calls the error page passing the error message.
            }
            var subsidiary = await _subsidiaryService.GetByIdAsync(id.Value); // Returns the subsidiary that contains this id.
            if (subsidiary == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 19. Report it." }); // Calls the error page passing the error message.
            }
            return View(subsidiary);
        }

        public IActionResult Error(string message) // Error page.
        {
            var ViewError = new ErrorViewModel() { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }; // Viewmodel instantiation.
            return View(ViewError);
        }
    }
}