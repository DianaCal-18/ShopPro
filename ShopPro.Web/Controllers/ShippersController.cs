using Microsoft.AspNetCore.Mvc;
using ShopPro.Web.Models.ShippersModels;
using ShopPro.Web.Services.IServices;


namespace ShopPro.Web.Controllers
{
    public class ShippersController : Controller
    {
        private readonly IShippersService _shippersService;

        public ShippersController(IShippersService shippersService)
        {
            _shippersService = shippersService;
        }

        // GET: ShippersController
        public async Task<ActionResult> Index()
        {
            var shippersGetList = await _shippersService.GetList();

            if (!shippersGetList.success)
            {
                ViewBag.Message = shippersGetList.message;
                return View();
            }

            return View(shippersGetList.data);
        }

        // GET: ShippersController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            var categoriesGetResult = await _shippersService.GetById(id);

            if (!categoriesGetResult.success)
            {
                ViewBag.Message = categoriesGetResult.message;
                return View();
            }

            return View(categoriesGetResult.data);

        }
            

        // GET: ShippersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST:ShippersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShippersModel saveModel)
        {
            try
            {
                var saveResult = await _shippersService.Save(saveModel);

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

        // GET: ShippersController/Edit/5

        public async Task<ActionResult> Edit(int id)
        {
            var categoriesGetResult = await _shippersService.GetById(id);

            if (!categoriesGetResult.success)
            {
                ViewBag.Message = categoriesGetResult.message;
                return View();
            }

            return View(categoriesGetResult.data);
        }


            // POST: ShippersController/Edit/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ShippersModel updateModel)
        {
            try
            {
                var updateResult = await _shippersService.Update(updateModel);

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

