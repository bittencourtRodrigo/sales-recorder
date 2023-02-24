using System;

namespace WebAppSalesMVC.Services.Exceptions
{
    public class NotFoundExeption : ApplicationException
    {
        public NotFoundExeption(string message) : base(message)
        {
        }
    }
}