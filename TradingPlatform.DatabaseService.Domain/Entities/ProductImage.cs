using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.DatabaseService.Domain.Entities
{
    [Table("ProductImages")]
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public virtual Product Product { get; set; }        
        [NotMapped]
        public byte[] ImageData { get; set; }
        public void PathToFile()
        {
            ImageData=File.ReadAllBytes(ImagePath);
        }
    }
}
