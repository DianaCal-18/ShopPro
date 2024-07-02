
namespace ShopPro.Common.Data.Base
{
    public abstract class BaseEntity<TType>
    {
        public abstract TType id { get; set; }
    }
}
