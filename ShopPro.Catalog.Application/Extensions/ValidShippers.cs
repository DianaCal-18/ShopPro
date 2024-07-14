
using ShopPro.Categories.Application.Base;
using ShopPro.Tables.Application.Dtos.CategoriesDtos;
using ShopPro.Tables.Application.Dtos.ShippersDtos;

namespace ShopPro.Tables.Application.Extensions
{
    public static class ValidShippers
    {
        public static ServiceResult IsValidShippers(this ShippersDto  shippersDto)
        {
            ServiceResult result = new ServiceResult();

            if (shippersDto is null)
            {
                result.Success = false;
                result.Message = $"El objeto{nameof(shippersDto)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(shippersDto.companyname) || shippersDto.companyname.Length > 40)
            {
                result.Success = false;
                result.Message = "El nombre de la company es requerido y no debe exceder los 40 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(shippersDto.phone) || shippersDto.phone.Length > 24)
            {
                result.Success = false;
                result.Message = "El phone es requerida y no debe exceder los 24 caracteres.";
                return result;
            }
            return result;
        }
    }
}
