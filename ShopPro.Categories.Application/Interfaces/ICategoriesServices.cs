using ShopPro.Categories.Application.Base;
using ShopPro.Tables.Application.Dtos.CategoriesDtos;

namespace ShopPro.Tables.Application.Interfaces
{
    public interface ICategoriesServices 
    {
        ServiceResult SaveCategories(CategoriesSaveDto categoriesSave);
        ServiceResult UpdateCategories (CategoriesUpdateDto categoriesUpdate);
        ServiceResult RemoveCategories(CategoriesRemoveDto categoriesRemove);
        ServiceResult GetCategories();
        ServiceResult GetCategoriesById(int categoryid);

    }
}
