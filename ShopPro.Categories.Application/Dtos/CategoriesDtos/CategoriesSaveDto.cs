
namespace ShopPro.Tables.Application.Dtos.CategoriesDtos
{
    public class CategoriesSaveDto : CategoriesDto
    {
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
    }
} 
