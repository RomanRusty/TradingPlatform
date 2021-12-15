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
    public abstract class Image
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "Extension must be less than 255 symbols.")]
        public string Extension { get; set; }
        [MaxLength(255, ErrorMessage = "Extension must be less than 255 symbols.")]
        public string Name { get; set; }
        [Required]
        public byte[] Data { get; set; }
    }
}