using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
