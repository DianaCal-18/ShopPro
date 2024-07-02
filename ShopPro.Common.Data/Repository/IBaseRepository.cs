

using System.Linq.Expressions;

namespace ShopPro.Common.Data.Repository
{
    public interface IBaseRepository<TEntity, TType> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetEntityByID(TType id);
        bool Exists(Expression<Func<TEntity, bool>> filter);
    }
}
