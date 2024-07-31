using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopPro.Web.Models.CategoriesModels;
using ShopPro.Web.Results.CategoriesResult;

namespace ShopPro.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClientHandler httpClientHandler;

        public CategoriesController()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            CategoriesGetListResult categoriesGetList = new CategoriesGetListResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:5218/api/Categories/GetCategories";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        categoriesGetList = JsonConvert.DeserializeObject<CategoriesGetListResult>(apiResponse);

                        if (!categoriesGetList.success)
                        {
                            ViewBag.Message = categoriesGetList.message;
                            return View();
                        }
                    }
                }
            }

            return View(categoriesGetList.data);
        }

        // GET: CategoriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5218/api/Categories/GetCategoryById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        var jsonObject = JObject.Parse(apiResponse);

                        var success = jsonObject["success"].Value<bool>();
                        var message = jsonObject["message"].Value<string>();

                        if (!success)
                        {
                            ViewBag.Message = message;
                            return View();
                        }
            
                        var category = jsonObject["data"].ToObject<CategoriesUpdateModel>(); 

                        if (category == null)
                        {
                            ViewBag.Message = "Category not found.";
                            return View();
                        }

                        return View(category);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener la categoría.";
                        return View();
                    }
                }
            }
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
                CategoriesSaveResult saveResult = new CategoriesSaveResult();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:5218/api/Categories/SaveCategories";

                    using (var response = await httpClient.PostAsJsonAsync<CategoriesSaveModel>(url, saveModel))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            saveResult = JsonConvert.DeserializeObject<CategoriesSaveResult>(apiResponse);

                            if (!saveResult.success)
                            {
                                ViewBag.Message = saveResult.message;
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.Message = saveResult.message;
                            return View();
                        }
                    }
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
            CategoriesGetResult categoriesGetResult = new CategoriesGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5218/api/Categories/GetCategoriesById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoriesGetResult = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);

                        if (!categoriesGetResult.success)
                        {
                            ViewBag.Message = categoriesGetResult.message;
                            return View();
                        }
                    }
                }
            }

            if (categoriesGetResult.data == null)
            {
                ViewBag.Message = "Category not found.";
                return View();
            }

            CategoriesUpdateModel updateModel = new CategoriesUpdateModel
            {
                categoryid = categoriesGetResult.data.id,
                categoryname = categoriesGetResult.data.categoryname,
                description = categoriesGetResult.data.description,
            };

            return View(updateModel);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoriesUpdateModel updateModel)
        {
            try
            {
                CategoriesGetResult categoriesGetResult = new CategoriesGetResult();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:5218/api/Categories/UpdateCategories";

                    using (var response = await httpClient.PutAsJsonAsync(url, updateModel))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            categoriesGetResult = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);

                            if (!categoriesGetResult.success)
                            {
                                ViewBag.Message = categoriesGetResult.message;
                                return View(updateModel);
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Error en la actualización de la categoría.";
                            return View(updateModel);
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = "Error inesperado.";
                return View(updateModel);
            }
        }
    }
}
