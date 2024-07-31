using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopPro.Web.Models.ShippersModels;
using ShopPro.Web.Results.ShippersResult;
using System.Net.Http.Json;
using System.Text;

namespace ShopPro.Web.Controllers
{
    public class ShippersController : Controller
    {
        private readonly HttpClientHandler httpClientHandler;

        public ShippersController()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        // GET: ShippersController
        public async Task<ActionResult> Index()
        {
            ShippersGetListResult shippersGetList = new ShippersGetListResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:5218/api/Shippers/GetShippers";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        shippersGetList = JsonConvert.DeserializeObject<ShippersGetListResult>(apiResponse);

                        if (!shippersGetList.success)
                        {
                            ViewBag.Message = shippersGetList.message;
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los shippers.";
                        return View();
                    }
                }
            }

            return View(shippersGetList.data);
        }

        // GET: ShippersController/Details/5
        public async Task<ActionResult> Details(int id)
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

                        var dataArray = jsonObject["data"].ToObject<List<ShippersModel>>();

                        if (dataArray == null || !dataArray.Any())
                        {
                            ViewBag.Message = "Shipper no encontrado.";
                            return View();
                        }

                        var shipper = dataArray.FirstOrDefault();
                        return View(shipper);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener el shipper.";
                        return View();
                    }
                }
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
                ShippersGetResult saveResult = new ShippersGetResult();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:5218/api/Shippers/SaveShippers";

                    using (var response = await httpClient.PostAsJsonAsync<ShippersModel>(url, saveModel))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            saveResult = JsonConvert.DeserializeObject<ShippersGetResult>(apiResponse);

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
        // GET: ShippersController/Edit/5
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

                        var dataArray = jsonObject["data"].ToObject<List<ShippersModel>>();

                        if (dataArray == null || !dataArray.Any())
                        {
                            ViewBag.Message = "Shipper no encontrado.";
                            return View(); 
                        }

                        var shipper = dataArray.FirstOrDefault();
                        return View(shipper); 
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener el shipper.";
                        return View(); 
                    }
                }
            }
        }

        // POST: ShippersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ShippersModel updateModel)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:5218/api/Shippers/UpdateShippers";
                    var content = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync(url, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var shippersGetResult = JsonConvert.DeserializeObject<ShippersGetResult>(apiResponse);

                            if (!shippersGetResult.success)
                            {
                                ViewBag.Message = shippersGetResult.message;
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
    }
}