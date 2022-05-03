using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.DatabaseService.Domain.Entities
{
    [Table("ProductImages")]
    public class ProductImage :Image
    {
        [Required]
        public virtual Product Product { get; set; }
    }
}
