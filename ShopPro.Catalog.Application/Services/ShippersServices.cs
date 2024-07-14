using ShopPro.Categories.Application.Base;
using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Tables.Application.Dtos.ShippersDtos;
using ShopPro.Tables.Application.Extensions;
using ShopPro.Tables.Application.Interfaces;
using ShopPro.Tables.Domain.Entitites;
using ShopPro.Tables.Domain.Interfaces;

namespace ShopPro.Tables.Application.Services
{
    public class ShippersServices : IShippersServices
    {
        private readonly IShippersRepository shippersRepository;
        private readonly ILoggerService logger;

        public ShippersServices(IShippersRepository shippersRepository, ILoggerService logger)
        {
            this.shippersRepository = shippersRepository;
            this.logger = logger;
        }
        public ServiceResult GetShippers()
        {
            var result = new ServiceResult();
            try
            {
                result.Data = shippersRepository.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las shippers.";
                logger.LogError(ex, result.Message);

            }
            return result;
        }

        public ServiceResult GetShippersById(int shipperid)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = shippersRepository.GetShippersById(shipperid);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo la shipper.";
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
                    result.Message = "Este campo es requerido. ";
                    return result;
                }

                var shippersEntity = new ShippersEntity
                {
                    id = shippersRemove.shipperid,
                    companyname = shippersRemove.companyname,
                    phone = shippersRemove.phone
                    

                };

                this.shippersRepository.Remove(shippersEntity);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando shippers. ";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult SaveShippers(ShippersDto shippersSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = shippersSave.IsValidShippers();
                if (!result.Success)
                {
                    return result;
                }

                var shippersEntity = new ShippersEntity
                {
                    id = shippersSave.shipperid,
                    companyname = shippersSave.companyname,
                    phone = shippersSave.phone
                };

                this.shippersRepository.Save(shippersEntity);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando la shipper.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult UpdateShippers(ShippersDto shippersUpdate)
        {
            ServiceResult result = new ServiceResult();
          try
            {
                result = shippersUpdate.IsValidShippers();
                if (!result.Success)
                {
                    return result;
                }

                var shippersEntity = new ShippersEntity
                {
                    id = shippersUpdate.shipperid,
                    companyname = shippersUpdate.companyname,
                    phone = shippersUpdate.phone
                };

                this.shippersRepository.Save(shippersEntity);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la shipper.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
