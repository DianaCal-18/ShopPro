using ShopPro.Web.Models.ShippersModels;
using ShopPro.Web.Results.ShippersResult;

namespace ShopPro.Web.Services.IServices
{
    public interface IShippersService
    {
        Task<ShippersGetListResult> GetList();
        Task<ShippersGetResult> GetById(int id);
        Task<ShippersGetResult> Save(ShippersModel saveModel);
        Task<ShippersGetResult> Update(ShippersModel updateModel);
    }
}
