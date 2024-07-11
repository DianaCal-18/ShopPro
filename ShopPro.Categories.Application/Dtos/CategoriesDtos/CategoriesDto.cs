using System.ComponentModel.DataAnnotations;

namespace ShopPro.Tables.Application.Dtos.CategoriesDtos
{
    public class CategoriesDto
    {
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public string description { get; set; }
    }
}
