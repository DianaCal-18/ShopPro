using ShopPro.Categories.Application.Base;
using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Tables.Application.Dtos.CategoriesDtos;
using ShopPro.Tables.Application.Extensions;
using ShopPro.Tables.Application.Interfaces;
using ShopPro.Tables.Domain.Entitites;
using ShopPro.Tables.Domain.Interfaces;

namespace ShopPro.Tables.Application.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly ILoggerService logger;

        public CategoriesServices(ICategoriesRepository categoriesRepository, ILoggerService logger)
        {
            this.categoriesRepository = categoriesRepository;
            this.logger = logger;
        }
        public ServiceResult GetCategories()
        {
            var result = new ServiceResult();
            try
            {
                result.Data = categoriesRepository.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las categories.";
                logger.LogError(ex, result.Message);

            }
            return result;

        }

        public ServiceResult GetCategoriesById(int categoryid)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = categoriesRepository.GetCategoriesById(categoryid);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo la category.";
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
                    result.Message = "Este campo es requerido. ";
                    return result;
                }

                var categoryEntity = new CategoriesEntity
                {
                    id = categoriesRemove.categoryid,
                    delete_user = categoriesRemove.delete_user,
                    delete_date = categoriesRemove.delete_date,
                    deleted = categoriesRemove.deleted
                };

                this.categoriesRepository.Remove(categoryEntity);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando la category.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult SaveCategories(CategoriesSaveDto categoriesSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = categoriesSave.IsValidCategories();

                if (!result.Success)
                {
                    return result;
                }
                var categoryEntity = new CategoriesEntity
                {
                    categoryname = categoriesSave.categoryname,
                    description = categoriesSave.description,
                    creation_date = categoriesSave.creation_date,
                    creation_user = categoriesSave.creation_user
                };

                this.categoriesRepository.Save(categoryEntity);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando la category.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult UpdateCategories(CategoriesUpdateDto categoriesUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (categoriesUpdate.categoryid == 0)
                {
                    result.Success = false;
                    result.Message = "El ID de la category es requerido.";
                    return result;
                }
                result = categoriesUpdate.IsValidCategories();

                if (!result.Success)
                {
                    return result;
                }

                var categoryEntity = new CategoriesEntity
                {
                    id = categoriesUpdate.categoryid,
                    categoryname = categoriesUpdate.categoryname,
                    description = categoriesUpdate.description,
                    modify_date = categoriesUpdate.modify_date,
                    modify_user = categoriesUpdate.modify_user
                };

                this.categoriesRepository.Update(categoryEntity);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la category.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
