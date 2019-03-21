using Microsoft.AspNetCore.Mvc;
using SatisCalc.Services;

namespace SatisCalc.Controllers
{
    public class AdminController : Controller
    {
        private IItemService itemService;

        public AdminController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Item()
        {
            var model = itemService.Get();
            return View(model);
        }
    }
}
