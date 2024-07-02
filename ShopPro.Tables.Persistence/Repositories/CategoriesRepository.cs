using ShopPro.Tables.Domain.Entitites;
using ShopPro.Tables.Domain.Interfaces;
using ShopPro.Tables.Persistence.Context;
using ShopPro.Tables.Persistence.Exceptions;
using ShopPro.Tables.Persistence.Extentions;
using System.Linq.Expressions;

namespace ShopPro.Tables.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ShopContext shopContext;
        public CategoriesRepository(ShopContext shopContext) 
        {
            this.shopContext = shopContext;
        }
        public bool Exists(Expression<Func<CategoriesEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CategoriesEntity> GetAll()
        {
          return this.shopContext.Categories.ToList();
        }

        public List<CategoriesEntity> GetCategoriesById(int categoryid)
        {
            var category = this.shopContext.Categories.Find(categoryid);
            if (category == null)
            {
                throw new CategoriesExceptions($"ID no encontrado, {categoryid}");
            }

            return new List<CategoriesEntity> { category };

        }

        public CategoriesEntity GetEntityByID(int id)
        {
            var category = this.shopContext.Categories.Find(id);
            if (category == null)
            {
                throw new CategoriesExceptions($"ID no encontrado, {id}");
            }

            return category;  
        }

        public void Remove(CategoriesEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save(CategoriesEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoriesEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
