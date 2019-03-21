using Microsoft.AspNetCore.Mvc;
using SatisCalc.Services;

namespace SatisCalc.Controllers
{
    public class ItemController : Controller
    {
        private IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public IActionResult Index()
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

            return new RedirectToActionResult("Index", "Item", null);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = itemService.Get(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Models.Item item)
        {
            itemService.Update(item);

            return new RedirectToActionResult("Index", "Item", null);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = itemService.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            itemService.Delete(id);

            return new RedirectToActionResult("Index", "Item", null);
        }
    }
}
