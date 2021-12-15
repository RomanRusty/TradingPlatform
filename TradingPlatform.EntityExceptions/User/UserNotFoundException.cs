using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.EntityExceptions.User
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
