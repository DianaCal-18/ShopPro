using Newtonsoft.Json;
using ShopPro.Web.Models.CategoriesModels;
using ShopPro.Web.Results.CategoriesResult;
using ShopPro.Web.Services.IServices;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopPro.Web.Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5218/api/Categories/";

        public CategoriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CategoriesGetResult> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}GetCategoriesById?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);
        }

        public async Task<CategoriesGetListResult> GetList()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}GetCategories");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoriesGetListResult>(apiResponse);
        }

        public async Task<CategoriesGetResult> Save(CategoriesSaveModel saveModel)
        {
            var jsonContent = JsonConvert.SerializeObject(saveModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            CreationUser(saveModel);
            var response = await _httpClient.PostAsync($"{BaseUrl}SaveCategories", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);
        }

        public async Task<CategoriesGetResult> Update(CategoriesUpdateModel updateModel)
        {
            var jsonContent = JsonConvert.SerializeObject(updateModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            ModifyUser(updateModel);
            var response = await _httpClient.PutAsync($"{BaseUrl}UpdateCategories", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);
        }




        private void CreationUser(CategoriesSaveModel saveModel)
        {
            saveModel.creation_date = DateTime.Now;
            saveModel.creation_user = 2;
        }

        private void ModifyUser(CategoriesUpdateModel updateModel)
        {
            updateModel.modify_date = DateTime.Now;
            updateModel.modify_user = 1;
        }
    }
}
