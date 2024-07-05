using ShopPro.Categories.Application.Base;
using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Tables.Application.Dtos.CategoriesDtos;
using ShopPro.Tables.Application.Extensions;
using ShopPro.Tables.Application.Interfaces;

namespace ShopPro.Tables.Application.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesServices categoriesServices;
        private readonly ILoggerService logger;

        public CategoriesServices(ICategoriesServices categoriesServices, ILoggerService logger)
        {
            this.categoriesServices = categoriesServices;
            this.logger = logger;
        }
        public ServiceResult GetCategories()
        {
            var result = new ServiceResult();
            try
            {
                result.Data = categoriesServices.GetCategories();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las categorías.";
                logger.LogError(ex, result.Message);

            }
            return result;

        }

        public ServiceResult GetCategoriesById(int categoryid)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = categoriesServices.GetCategoriesById(categoryid);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo la categoría.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult RemoveCategories(CategoriesRemoveDto categoriesRemove)
        {
            var result = new ServiceResult();
            try
            {
                if (categoriesRemove == null)
                {
                    result.Success = false;
                    return result;
                }
                categoriesServices.RemoveCategories(categoriesRemove);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando la categoría.";
                logger.LogError(ex, result.Message);

            }
            return result;
        }

        public ServiceResult SaveCategories(CategoriesSaveDto categoriesSave)
        {
            var result = EntityExtension<CategoriesSaveDto>.Validate(categoriesSave);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                categoriesServices.SaveCategories(categoriesSave);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando la categoría.";
                logger.LogError(ex, result.Message);
            }
            return result; ;
        }

        public ServiceResult UpdateCategories(CategoriesUpdateDto categoriesUpdate)
        {
            var result = EntityExtension<CategoriesUpdateDto>.Validate(categoriesUpdate);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                categoriesServices.UpdateCategories(categoriesUpdate);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la categoría.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
