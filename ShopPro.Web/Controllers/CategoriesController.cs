using Microsoft.AspNetCore.Mvc;
using ShopPro.Web.Models.CategoriesModels;
using ShopPro.Web.Services.IServices;

namespace ShopPro.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            var categoriesGetList = await _categoriesService.GetList();

            if (!categoriesGetList.success)
            {
                ViewBag.Message = categoriesGetList.message;
                return View();
            }

            return View(categoriesGetList.data);
        }

        // GET: CategoriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var categoriesGetResult = await _categoriesService.GetById(id);

            if (!categoriesGetResult.success)
            {
                ViewBag.Message = categoriesGetResult.message;
                return View();
            }

            return View(categoriesGetResult.data);
        }


        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoriesSaveModel saveModel)
        {
            try
            {
                var saveResult = await _categoriesService.Save(saveModel);

                if (!saveResult.success)
                {
                    ViewBag.Message = saveResult.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5

        public async Task<ActionResult> Edit(int id)
        {
            var categoriesGetResult = await _categoriesService.GetById(id);

            if (!categoriesGetResult.success)
            {
                ViewBag.Message = categoriesGetResult.message;
                return View();
            }

            return View(categoriesGetResult.data);
        }



        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoriesUpdateModel updateModel)
        {

            try
            {

                var updateResult = await _categoriesService.Update(updateModel);

                if (!updateResult.success)
                {
                    ViewBag.Message = updateResult.message;
                    return View(updateModel);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View(updateModel);
            }

        }

    }




}
