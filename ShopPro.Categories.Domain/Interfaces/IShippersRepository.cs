using ShopPro.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPro.Tables.Domain.Interfaces
{
    public interface IShippersRepository : IBaseRepository<IShippersRepository, int>
    {
        List<Tables.Domain.Entitites.ShippersEntity> GetCategoriesById(int categoryid);
    }
}
