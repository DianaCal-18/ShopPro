using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopPro.Web.Models.CategoriesModels;
using ShopPro.Web.Results.CategoriesResult;
using System.Text;

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
                var url = $"http://localhost:5218/api/Categories/GetCategoriesById?id={id}";

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

                        var data = jsonObject["data"].ToObject<List<CategoriesUpdateModel>>();

                        if (data == null || !data.Any())
                        {
                            ViewBag.Message = "Shipper no encontrado.";
                            return View();
                        }

                        var categories = data.FirstOrDefault();
                        return View(categories);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener el shipper.";
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
                            CreationUser(saveModel);
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
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5218/api/Shippers/GetShippersById?id={id}";

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

                        var data = jsonObject["data"].ToObject<List<CategoriesUpdateModel>>();

                        if (data == null || !data.Any())
                        {
                            ViewBag.Message = "categoy no encontrado.";
                            return View();
                        }

                        var categories = data.FirstOrDefault();
                        return View(categories);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener la category.";
                        return View();
                    }
                }
            }
        }



        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoriesUpdateModel updateModel)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:5218/api/Categories/UpdateCategories";
                    var content = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync(url, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ModifyUser(updateModel);
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var GetResult = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);

                            if (!GetResult.success)
                            {
                                ViewBag.Message = GetResult.message;
                                return View(updateModel);
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Error en la actualización del shipper.";
                            return View(updateModel);
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View(updateModel);
            }
     
         
        
    }


        public void CreationUser(CategoriesSaveModel saveModel)
        {
            saveModel.creation_date = DateTime.Now;
            saveModel.creation_user = 2;
        }

        public void ModifyUser(CategoriesUpdateModel updateModel)
        {
            updateModel.modify_date = DateTime.Now;
            updateModel.modify_user = 1;
        }
    }




}
