using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShopPro.Tables.Domain.Entitites;

namespace ShopPro.Tables.Persistence.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        #region"Db Sets"
        public DbSet<CategoriesEntity> Categories { get; set; }
        public DbSet<ShippersEntity> Shippers { get; set; }
        #endregion
    }
}
