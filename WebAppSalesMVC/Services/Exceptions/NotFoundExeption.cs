using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSalesMVC.Services.Exceptions
{
    public class NotFoundExeption : ApplicationException
    {
        public NotFoundExeption(string message) : base(message)
        {
        }
    }
}
