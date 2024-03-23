using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string messagem) : base(messagem)
        {

        }
    }
}
