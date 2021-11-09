using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.Domain.Exceptions.Order
{
    public class OrderAlreadyExistsException : BadRequestException
    {
        public OrderAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
