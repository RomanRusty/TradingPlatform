﻿using System;
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
    public class ProductImage :Image
    {
        [Required]
        public virtual Product Product { get; set; }
    }
}
