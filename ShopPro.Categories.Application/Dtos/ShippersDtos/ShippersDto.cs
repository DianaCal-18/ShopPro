using System.ComponentModel.DataAnnotations;

namespace ShopPro.Tables.Application.Dtos.ShippersDtos
{
    public class ShippersDto
    {
        public int shipperid { get; set; }

        [StringLength(40, ErrorMessage = "No se pueden exceder de 40 caracteres.")]
        public string companyname { get; set; }

        [StringLength(24, ErrorMessage = "No se pueden exceder de 24 caracteres.")]
        public string phone { get; set; }
    }
}
