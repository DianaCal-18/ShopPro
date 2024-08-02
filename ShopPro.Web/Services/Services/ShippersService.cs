using Newtonsoft.Json;
using ShopPro.Web.Services.IServices;
using ShopPro.Web.Results.ShippersResult;
using ShopPro.Web.Models.ShippersModels;
using System.Text;

namespace ShopPro.Web.Services.Services
{
    public class ShippersService : IShippersService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5218/api/Shippers/";

        public ShippersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ShippersGetResult> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}GetShippersById?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ShippersGetResult>(apiResponse);
        }

        public async Task<ShippersGetListResult> GetList()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}GetShippers");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ShippersGetListResult>(apiResponse);
        }

        public async Task<ShippersGetResult> Save(ShippersModel saveModel)
        {
            var jsonContent = JsonConvert.SerializeObject(saveModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}SaveShippers", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ShippersGetResult>(apiResponse);
        }

        public async Task<ShippersGetResult> Update(ShippersModel updateModel)
        {
            var jsonContent = JsonConvert.SerializeObject(updateModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{BaseUrl}UpdateShippers", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ShippersGetResult>(apiResponse);
        }
    }
}
