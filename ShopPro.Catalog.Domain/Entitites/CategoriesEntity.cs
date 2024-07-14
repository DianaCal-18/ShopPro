using ShopPro.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopPro.Tables.Domain.Entitites
{
    [Table("Categories", Schema = "Production")]
    public class CategoriesEntity : AuditEntity<int>
    {
        [Key]
        [Column("categoryid")]
        public override int id { get; set; }
        public string? categoryname { get; set; }
        public string? description { get; set; }
    }


}
