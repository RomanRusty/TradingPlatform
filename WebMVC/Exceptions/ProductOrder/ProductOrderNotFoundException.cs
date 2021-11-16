using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.WebMvc.Exceptions.ProductOrder
{
    public class ProductOrderNotFoundException : NotFoundException
    {
        public ProductOrderNotFoundException(string message) : base(message)
        {
        }
    }
}
