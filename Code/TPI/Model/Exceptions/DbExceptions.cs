using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Exceptions
{
    public class DbError : Exception
    {
        public DbError()
            : base("La base de donnée n'est pas opérationelle. L'application est limitée.")
        { }
    }
}
