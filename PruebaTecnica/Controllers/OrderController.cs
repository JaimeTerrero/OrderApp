using Application.Services;
using Application.ViewModels.Order;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderServices _orderServices;
        private readonly ProductServices _productServices;
        private readonly ClientServices _clientServices;
        public OrderController(ApplicationContext dbContext)
        {
            _orderServices = new(dbContext);
            _productServices = new(dbContext);
            _clientServices = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _orderServices.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            SaveOrderViewModel vm = new();
            vm.Products = await _productServices.GetAllViewModel();
            vm.Clients = await _clientServices.GetAllViewModel();
            return View("SaveOrder", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveOrderViewModel vm)
        {
            await _orderServices.Add(vm);
            return RedirectToRoute(new { controller = "Order", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            SaveOrderViewModel vm = await _orderServices.GetByIdViewModel(id);
            vm.Products = await _productServices.GetAllViewModel();
            vm.Clients = await _clientServices.GetAllViewModel();
            return View("SaveOrder", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveOrderViewModel vm)
        {
            await _orderServices.Update(vm);
            return RedirectToRoute(new { controller = "Order", action = "Index" });
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _orderServices.GetByIdViewModel(id);
            await _orderServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
