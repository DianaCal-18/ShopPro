using ShopPro.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopPro.Tables.Domain.Entitites
{
    [Table("Shippers", Schema = "Sales")]

    public class ShippersEntity : BaseEntity<int>
    {
        [Key]
        [Column("shipperid")]
        public override int id { get; set; }
        public string? companyname { get; set; }
        public string? phone { get; set; }


    }
}
