using System.ComponentModel.DataAnnotations;

namespace ShopPro.Tables.Application.Dtos.CategoriesDtos
{
    public class CategoriesDto
    {
        public int categoryid { get; set; }

        [StringLength(15, ErrorMessage = "No se pueden exceder de 15 caracteres.")]
        public string categoryname { get; set; }

        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string description { get; set; }
    }
}
