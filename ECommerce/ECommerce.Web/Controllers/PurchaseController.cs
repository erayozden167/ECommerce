using ECommerce.Business;
using ECommerce.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly PurchaseService _purchaseService;
        public PurchaseController(PurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Purchase(PurchaseDTO request)
        {
            if (!ModelState.IsValid)
            {
                return View(BadRequest());
            }
            int userId = 1; // for now
            request.UserId = userId;

            bool response = await _purchaseService.PurchaseAsync(request);

            if (!response)
            {
                return View(BadRequest());
            }


            return View(Ok());
        }
    }

}
