using Microsoft.Extensions.DependencyInjection;
using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Infraestructure.Logger.Services;
using ShopPro.Tables.Application.Interfaces;
using ShopPro.Tables.Application.Services;
using ShopPro.Tables.Domain.Interfaces;
using ShopPro.Tables.Persistence.Repositories;

namespace ShopPro.Tables.IOC.Dependencies
{
    public static class CatalogDependencies
    {
        public static void AddCatalogDependencies(this IServiceCollection service)
        {
            #region"Repositories"
            service.AddScoped<IShippersRepository, ShippersRepository>();
            service.AddScoped<ICategoriesRepository, CategoriesRepository>();
            #endregion

            #region "Services"
            service.AddTransient<ICategoriesServices, CategoriesServices>();
            service.AddTransient<IShippersServices, ShippersServices>();
            service.AddScoped<ILoggerService, LoggerService>();
            #endregion


        }
    }
}
