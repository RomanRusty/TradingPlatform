using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.DatabaseService.Domain.Entities
{
    [Table("ProductImageThumbnails")]
  
    public class ProductImageThumbnail:Image
    {
        [Required]
        [ForeignKey("Product")]
        public int ProudctId { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}
