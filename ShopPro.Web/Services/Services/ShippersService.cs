using ShopPro.Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;
using ShopPro.Web.Results.ShippersResult;
using ShopPro.Web.Models.ShippersModels;

namespace ShopPro.Web.Services.Services
{
    public class ShippersService : IShippersService
    {
        private readonly HttpClientHandler httpClientHandler;
        private const string BaseUrl = "http://localhost:5218/api/Shippers/";

        public ShippersService()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        public async Task<ShippersGetResult> GetById(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}GetShippersById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ShippersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new ShippersGetResult { success = false, message = "Error al obtener la shipper." };
                    }
                }
            }
        }
        public async Task<ShippersGetListResult> GetList()
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}GetShippers";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ShippersGetListResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new ShippersGetListResult { success = false, message = "Error al obtener la lista de shippers." };
                    }
                }
            }
        }

        public async Task<ShippersGetResult> Save(ShippersModel saveModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}SaveShippers";
                var content = new StringContent(JsonConvert.SerializeObject(saveModel), Encoding.UTF8, "application/json");
   
                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ShippersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new ShippersGetResult { success = false, message = "Error al guardar  el shipper." };
                    }
                }
            }
        }

        public async Task<ShippersGetResult> Update(ShippersModel updateModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}UpdateShippers";
                var content = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");
                
                using (var response = await httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ShippersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new ShippersGetResult { success = false, message = "Error al actualizar el shipper." };
                    }
                }
            }
        }
    }
}