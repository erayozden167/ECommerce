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
        [HttpPost]
        public async Task<IActionResult> Purchase(PurchaseDTO request)
        {
            if (!ModelState.IsValid)
            {
                return View(BadRequest());
            }
            int userId = 1; // for now
            request.UserId = userId;

            bool response = await _purchaseService.PurchaseAddAsync(request);

            if (!response)
            {
                return View(BadRequest());
            }


            return View(Ok());
        }
        [HttpGet]
        public async Task<IActionResult> GetPurchaseByUser(int id)
        {
            PurchaseDTO purchase = await _purchaseService.GetPurchaseAsync(id);





            return View(Ok());
        }
    }

}
