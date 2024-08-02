using Microsoft.AspNetCore.Mvc;
using ShopPro.Web.Models.ShippersModels;
using ShopPro.Web.Services.IServices;
using System;

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
            try
            {
                var shippersGetList = await _shippersService.GetList();

                if (!shippersGetList.success)
                {
                    ViewBag.Message = shippersGetList.message;
                    return View();
                }

                return View(shippersGetList.data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View();
            }
        }

        // GET: ShippersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var shippersGetResult = await _shippersService.GetById(id);

                if (!shippersGetResult.success)
                {
                    ViewBag.Message = shippersGetResult.message;
                    return View();
                }

                return View(shippersGetResult.data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View();
            }
        }

        // GET: ShippersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippersController/Create
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
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View();
            }
        }

        // GET: ShippersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var shippersGetResult = await _shippersService.GetById(id);

                if (!shippersGetResult.success)
                {
                    ViewBag.Message = shippersGetResult.message;
                    return View();
                }

                return View(shippersGetResult.data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View();
            }
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
