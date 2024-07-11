
using ShopPro.Categories.Application.Base;
using ShopPro.Tables.Application.Dtos.CategoriesDtos;

namespace ShopPro.Tables.Application.Extensions
{
    public static class ValidCategories
    {
        public static ServiceResult IsValidCategories(this CategoriesDto categoriesDto)
        {
            ServiceResult result = new ServiceResult();

            if (categoriesDto is null)
            {
                result.Success = false;
                result.Message = $"El objeto{nameof(categoriesDto)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(categoriesDto.categoryname) || categoriesDto.categoryname.Length > 15)
            {
                result.Success = false;
                result.Message = "El nombre de la category es requerido y no debe exceder los 15 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(categoriesDto.description) || categoriesDto.description.Length > 200)
            {
                result.Success = false;
                result.Message = "La description es requerida y no debe exceder los 200 caracteres.";
                return result;
            }
            return result;
        }
    }
}


