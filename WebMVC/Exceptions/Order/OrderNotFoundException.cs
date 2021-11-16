using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Exceptions.Order
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(string message) : base(message)
        {
        }
    }
}
