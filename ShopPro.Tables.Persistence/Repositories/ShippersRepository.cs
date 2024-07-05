using ShopPro.Tables.Domain.Entitites;
using ShopPro.Tables.Domain.Interfaces;
using System.Linq.Expressions;

namespace ShopPro.Tables.Persistence.Repositories
{
    public class ShippersRepository : IShippersRepository
    {
        public bool Exists(Expression<Func<IShippersRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<IShippersRepository> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ShippersEntity> GetCategoriesById(int categoryid)
        {
            throw new NotImplementedException();
        }

        public IShippersRepository GetEntityByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(IShippersRepository entity)
        {
            throw new NotImplementedException();
        }

        public void Save(IShippersRepository entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IShippersRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
