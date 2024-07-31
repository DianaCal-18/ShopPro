using ShopPro.Web.Models.CategoriesModels;
using ShopPro.Web.Results.Base;
using ShopPro.Web.Results.CategoriesResult;

namespace ShopPro.Web.Services.IServices
{
    public interface ICategoriesService
    {
        Task<CategoriesGetListResult> GetList();
        Task<CategoriesGetResult> GetById(int id);
        Task<CategoriesGetResult> Save (CategoriesSaveModel saveModel);
        Task<CategoriesGetResult> Update(CategoriesUpdateModel updateModel);
    }
}
