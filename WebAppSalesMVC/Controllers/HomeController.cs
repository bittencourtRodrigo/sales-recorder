using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WebAppSalesMVC.Models.ViewModels;
using WebAppSalesMVC.Services;

namespace WebAppSalesMVC.Controllers
{
    public class HomeController : Controller
    {
        public readonly StateService _stateService;

        public HomeController(StateService stateService)
        {
            _stateService = stateService;
        }

        public async Task<IActionResult> Index() // Initial page.
        {
            var states = await _stateService.GetStatesAsync(); // Returns a list of registered states.
            if (states == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Error 01. Report it." }); // Calls the error page passing the error message.
            }
            return View(states);
        }

        public IActionResult Error(string message) // Error page.
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message }); // ViewModel instantiation.
        }
    }
}