using ShopPro.Web.Models.CategoriesModels;
using ShopPro.Web.Results.CategoriesResult;
using ShopPro.Web.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopPro.Web.Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly HttpClientHandler httpClientHandler;
        private const string BaseUrl = "http://localhost:5218/api/Categories/";

        public CategoriesService()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        public async Task<CategoriesGetResult> GetById(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}GetCategoriesById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new CategoriesGetResult { success = false, message = "Error al obtener la categoría." };
                    }
                }
            }
        }

        public async Task<CategoriesGetListResult> GetList()
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}GetCategories";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CategoriesGetListResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new CategoriesGetListResult { success = false, message = "Error al obtener la lista de categorías." };
                    }
                }
            }
        }

        public async Task<CategoriesGetResult> Save(CategoriesSaveModel saveModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}SaveCategories";
                var content = new StringContent(JsonConvert.SerializeObject(saveModel), Encoding.UTF8, "application/json");
                CreationUser(saveModel);

                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new CategoriesGetResult { success = false, message = "Error al guardar la categoría." };
                    }
                }
            }
        }

        public async Task<CategoriesGetResult> Update(CategoriesUpdateModel updateModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}UpdateCategories";
                var content = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");
                ModifyUser(updateModel);
                using (var response = await httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new CategoriesGetResult { success = false, message = "Error al actualizar la categoría." };
                    }
                }
            }
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
