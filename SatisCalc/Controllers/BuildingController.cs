using Microsoft.AspNetCore.Mvc;
using SatisCalc.Services;

namespace SatisCalc.Controllers
{
    public class BuildingController : Controller
    {
        private IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        public IActionResult Index()
        {
            var model = buildingService.Get();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new Models.Building();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Models.Building model)
        {
            buildingService.Add(model);

            return new RedirectToActionResult("Index", "Building", null);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = buildingService.Get(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Models.Building model)
        {
            buildingService.Update(model);

            return new RedirectToActionResult("Index", "Building", null);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = buildingService.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            buildingService.Delete(id);

            return new RedirectToActionResult("Index", "Building", null);
        }
    }
}
