
using ShopPro.Categories.Application.Base;
using ShopPro.Tables.Application.Dtos.ShippersDtos;

namespace ShopPro.Tables.Application.Interfaces
{
    public interface IShippersServices
    {
        ServiceResult SaveShippers(ShippersDto shippersSave);
        ServiceResult UpdateShippers(ShippersDto shippersUpdate);
        ServiceResult RemoveShippers(ShippersDto shippersRemove);
        ServiceResult GetShippers();
        ServiceResult GetShippersById(int shipperid);
    }
}
