
namespace ShopPro.Tables.Application.Dtos.CategoriesDtos
{
    public class CategoriesRemoveDto: CategoriesDto
    {
        public int delete_user { get; set; }
        public DateTime delete_date { get; set; }
        public bool deleted { get; set; } = false;
    }
}
