using ShopPro.Common.Data.Repository;
using ShopPro.Tables.Domain.Entitites;

namespace ShopPro.Tables.Domain.Interfaces
{
    public interface IShippersRepository : IBaseRepository<ShippersEntity, int>
    {
        List<Tables.Domain.Entitites.ShippersEntity> GetShippersById(int shipperid);
    }
}
