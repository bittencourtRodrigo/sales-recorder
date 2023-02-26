using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Models;
using WebAppSalesMVC.Models.ViewModels;
using WebAppSalesMVC.Services;

namespace WebAppSalesMVC.Controllers
{
    public class StatesController : Controller
    {
        private readonly WebAppSalesMVCContext _context;
        private readonly StateService _stateService;

        public StatesController(WebAppSalesMVCContext context, StateService stateService)
        {
            _context = context;
            _stateService = stateService;
        }

        public async Task<IActionResult> Index() // Initial page.
        {
            var states = await _stateService.GetStatesIncSubsAsync(); // Returns a list of registered states.
            return View(states);
        }

        public IActionResult Create() // Page state create.
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 4. Report it." }); // Calls the error page passing the error message.
            }

            var state = await _stateService.GetByIdAsync(id.Value); // Returns the state that contains this id.
            if (state == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 5. Report it." }); // Calls the error page passing the error message.
            }
            return View(state);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] State state) // Scarfoldin spawned. Is intact, for future studies.
        {
            if (ModelState.IsValid)
            {
                _context.Add(state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 6. Report it." }); // Calls the error page passing the error message.
            }
            var state = await _stateService.GetByIdAsync(id.Value); // Returns the state that contains this id.
            if (state == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 7. Report it." }); // Calls the error page passing the error message.
            }
            return View(state);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] State state) // Scarfoldin spawned. Is intact, for future studies.
        {
            if (id != state.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(state);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateExists(state.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 8. Report it." }); // Calls the error page passing the error message.
            }
            var state = await _stateService.GetByIdAsync(id.Value); // Returns the state that contains this id.
            if (state == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 9. Report it." }); // Calls the error page passing the error message.
            }
            return View(state);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // Scarfoldin spawned. For future studies.
        {
            try // Edit
            {
                var state = await _context.State.FindAsync(id);
                _context.State.Remove(state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException) // Edit
            {
                return RedirectToAction(nameof(Error), new { message = "Error 10. You have tried to exclude a state with subsidiaries." }); // Calls the error page passing the error message.
            }
        }

        private bool StateExists(int id) // Scarfoldin spawned. Is intact, for future studies.
        {
            return _context.State.Any(e => e.Id == id);
        }

        public IActionResult Error(string message) // Error page.
        {
            var ViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message }; // ViewModel instantiation.
            return View(ViewModel);
        }
    }
}