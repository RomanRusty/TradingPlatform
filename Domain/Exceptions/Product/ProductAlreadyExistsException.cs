using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.DatabaseService.Domain.Exceptions.Product
{
    public class ProductAlreadyExistsException:BadRequestException
    {
        public ProductAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
