using Microsoft.AspNetCore.Mvc;
using MedicationOrderSystem.Models;

namespace MedicationOrderSystem.Controllers
{
    public class OrderController : Controller
    {

        [HttpPost]
        public IActionResult Submit(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {

                return View("OrderSummary", model);
            }

            return RedirectToAction("Index", "Home");
        }

        // Action to display the Order Summary page
        public IActionResult OrderSummary(OrderViewModel model)
        {
            return View(model);
        }

        // Action to show the Order Success page after successful order submission
        public IActionResult OrderSuccess()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
