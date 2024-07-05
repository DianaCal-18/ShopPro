using ShopPro.Tables.Domain.Entitites;
using ShopPro.Tables.Domain.Interfaces;
using ShopPro.Tables.Persistence.Context;
using ShopPro.Tables.Persistence.Exceptions;
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
            return this.shopContext.Categories.Any(filter);
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
            var categoryList = new List<CategoriesEntity> { category };

            return categoryList;

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
            var category = this.shopContext.Categories.Find(entity.id);
            category = ValidarExistencia(entity.id);
            this.shopContext.Categories.Remove(category);
            this.shopContext.SaveChanges();
        }

        public void Save(CategoriesEntity entity)
        {
            if (entity == null)
            {
                throw new CategoriesExceptions(nameof(entity));
            }

            this.shopContext.Categories.Add(entity);
            this.shopContext.SaveChanges();
        }

        public void Update(CategoriesEntity entity)
        {
            if (entity == null)
            {
                throw new CategoriesExceptions(nameof(entity));
            }

            var category = this.shopContext.Categories.Find(entity.id);

            if (category == null)
            {
                throw new CategoriesExceptions($"ID no encontrado, {entity.id}");
            }

            category.categoryname = entity.categoryname;
            category.description = entity.description;

            this.shopContext.Categories.Update(category);
            this.shopContext.SaveChanges();
        }

        private CategoriesEntity ValidarExistencia(int categoryid)
        {
            var categories = this.shopContext.Categories.Find(categoryid);
            return categories;
        }
    }
}
