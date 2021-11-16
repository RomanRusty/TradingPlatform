using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Exceptions.Complaint
{
    public class ComplaintAlreadyExistsException : BadRequestException
    {
        public ComplaintAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
