using Application.Services;
using Application.ViewModels.Client;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientServices _clientServices;
        public ClientController(ApplicationContext dbContext)
        {
            _clientServices = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _clientServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            ClientViewModel vm = new();
            return View("SaveClient", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel vm)
        {
            await _clientServices.Add(vm);
            return RedirectToRoute(new { controller = "Client", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveClient", await _clientServices.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel vm)
        {
            await _clientServices.Update(vm);
            return RedirectToRoute(new { controller = "Client", action = "Index" });
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _clientServices.GetByIdViewModel(id);
            await _clientServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
