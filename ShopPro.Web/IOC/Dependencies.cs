using ShopPro.Web.Services.IServices;
using ShopPro.Web.Services.Services;

namespace ShopPro.Web.IOC
{
    public static class Dependencies
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            #region "HttClient"
            service.AddHttpClient<ICategoriesService, CategoriesService>();
            service.AddHttpClient<IShippersService, ShippersService>();
            #endregion

            #region "AddScope"
            service.AddScoped<ICategoriesService, CategoriesService>();
            service.AddScoped<IShippersService, ShippersService>();
            #endregion


        }
    }
}
