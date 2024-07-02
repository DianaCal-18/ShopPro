
namespace ShopPro.Tables.Application.Dtos.CategoriesDtos
{
    public class CategoriesUpdateDto: CategoriesDto
    {
        public DateTime modify_date { get; set; }
        public int? modify_user { get; set; }

    }
}
