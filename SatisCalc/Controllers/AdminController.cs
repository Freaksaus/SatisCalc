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

        [HttpGet]
        public IActionResult Add()
        {
            var model = new Models.Item();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Models.Item item)
        {
            itemService.Add(item);

            return new RedirectResult("Item");
        }
    }
}
