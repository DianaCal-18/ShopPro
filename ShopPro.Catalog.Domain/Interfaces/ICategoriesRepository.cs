using ShopPro.Common.Data.Repository;
using ShopPro.Tables.Domain.Entitites;

namespace ShopPro.Tables.Domain.Interfaces
{
    public interface ICategoriesRepository : IBaseRepository<Domain.Entitites.CategoriesEntity, int>
    {

        List<Tables.Domain.Entitites.CategoriesEntity> GetCategoriesById(int categoryid);



    }
}
