using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.DataAccess
{
    [Table("ProductImages")]
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
        [Required]
        public virtual Product Product { get; set; }        
        public string GetImage()
        {
            var base64 = Convert.ToBase64String(ImageData);
            var image = string.Format("data:image/gif;base64,{0}", base64);
            return image;
        }
    }
}
