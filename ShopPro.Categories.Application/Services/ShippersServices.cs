using ShopPro.Categories.Application.Base;
using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Tables.Application.Dtos.ShippersDtos;
using ShopPro.Tables.Application.Extensions;
using ShopPro.Tables.Application.Interfaces;

namespace ShopPro.Tables.Application.Services
{
    public class ShippersServices : IShippersServices
    {
        private readonly IShippersServices shippersServices;
        private readonly ILoggerService logger;

        public ShippersServices(IShippersServices shippersServices, ILoggerService logger)
        {
            this.shippersServices = shippersServices;
            this.logger = logger;
        }
        public ServiceResult GetShippers()
        {
            var result = new ServiceResult();
            try
            {
                result.Data = shippersServices.GetShippers();
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

        public ServiceResult GetShippersById(int shipperid)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = shippersServices.GetShippersById(shipperid);
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

        public ServiceResult RemoveShippers(ShippersDto shippersRemove)
        {
            var result = new ServiceResult();
            try
            {
                if (shippersRemove == null)
                {
                    result.Success = false;
                    return result;
                }
                shippersServices.RemoveShippers(shippersRemove);
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

        public ServiceResult SaveShippers(ShippersDto shippersSave)
        {
            var result = EntityExtension<ShippersDto>.Validate(shippersSave);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                shippersServices.SaveShippers(shippersSave);
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

        public ServiceResult UpdateShippers(ShippersDto shippersUpdate)
        {
            var result = EntityExtension<ShippersDto>.Validate(shippersUpdate);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                shippersServices.UpdateShippers(shippersUpdate);
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
