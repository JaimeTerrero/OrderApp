using Application.Services;
using Application.ViewModels.Product;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServices _productServices;
        public ProductController(ApplicationContext dbContext)
        {
            _productServices = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productServices.GetAllViewModel());
        }


        public IActionResult Create()
        {
            ProductViewModel vm = new();
            return View("SaveProduct", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel vm)
        {
            await _productServices.Add(vm);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveProduct", await _productServices.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel vm)
        {
            await _productServices.Update(vm);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _productServices.GetByIdViewModel(id);
            await _productServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
