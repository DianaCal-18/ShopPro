using ShopPro.Tables.Domain.Entitites;
using ShopPro.Tables.Domain.Interfaces;
using ShopPro.Tables.Persistence.Context;
using ShopPro.Tables.Persistence.Exceptions;
using System.Linq.Expressions;

namespace ShopPro.Tables.Persistence.Repositories
{
    public class ShippersRepository : IShippersRepository
    {
        private readonly ShopContext shopContext;

        public ShippersRepository(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public bool Exists(Expression<Func<ShippersEntity, bool>> filter)
        {
            return this.shopContext.Shippers.Any(filter);
        }

        public List<ShippersEntity> GetAll()
        {
            return this.shopContext.Shippers
                     .OrderByDescending(c => c.id)
                     .ToList();
        }


         public List<ShippersEntity> GetShippersById(int shipperid)
         {
             var shippers = this.shopContext.Shippers.Find(shipperid);
             if (shippers == null)
             {
                 throw new ShippersExceptions($"ID no encontrado, {shipperid}");
             }

             var shippersList = new List<ShippersEntity> { shippers };
             return shippersList;
         } 
        
        public ShippersEntity GetEntityByID(int id)
        {
            var shippers = this.shopContext.Shippers.Find(id);
            if(shippers == null)
            {
                throw new ShippersExceptions($"ID no encontrado, {id}");
            }

            return shippers;
        }

        public void Remove(ShippersEntity entity)
        {
            var shippers = this.shopContext.Shippers.Find(entity.id);
            shippers = ValidarExistencia(entity.id);
            this.shopContext.Shippers.Remove(shippers);
            this.shopContext.SaveChanges();
        }

        public void Save(ShippersEntity entity)
        {
           if (entity == null)
            {
                throw new ShippersExceptions(nameof(entity));
            }

            this.shopContext.Shippers.Add(entity);
            this.shopContext.SaveChanges();
        }

        public void Update(ShippersEntity entity)
        {
            if (entity == null)
            {
                throw new ShippersExceptions(nameof(entity));
            }
            var shippers = this.shopContext.Shippers.Find(entity.id);
            if(shippers == null)
            {
                throw new ShippersExceptions($"ID no encontrado {entity.id}");
            }

            shippers.companyname = entity.companyname;
            shippers.phone = shippers.phone;

            this.shopContext.Shippers.Update(shippers);
            this.shopContext.SaveChanges();
        }

        private ShippersEntity ValidarExistencia(int shipperid)
        {
            var shippers = this.shopContext.Shippers.Find(shipperid);
            return shippers;
        }
    }
}
