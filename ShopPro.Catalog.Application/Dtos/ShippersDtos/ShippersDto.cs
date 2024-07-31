using System.ComponentModel.DataAnnotations;

namespace ShopPro.Tables.Application.Dtos.ShippersDtos
{
    public class ShippersDto
    {
        public int shipperid { get; set; }
        public string companyname { get; set; }
        public string phone { get; set; }
    }
}
