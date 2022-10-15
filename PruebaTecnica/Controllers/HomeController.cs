using Application.Services;
using Application.ViewModels.Order;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderServices _orderServices;
        private readonly ProductServices _productServices;
        public HomeController(ApplicationContext dbContext)
        {
            _orderServices = new(dbContext);
            _productServices = new(dbContext);
        }

        public async Task<IActionResult> Index(FilterOrderViewModel vm)
        {
            ViewBag.Products = await _productServices.GetAllViewModel();
            return View(await _orderServices.GetAllViewModelWithFilters(vm));
        }
    }
}
