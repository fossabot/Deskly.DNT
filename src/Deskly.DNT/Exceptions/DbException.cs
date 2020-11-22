using System;
using System.Collections.Generic;
using System.Text;

namespace Deskly.DNT.Exceptions
{
    [Serializable]
    public class DbException : FrameworkException
    {
        public DbException(string message, Exception innerException)
        : base(message, innerException)
        {
        }
    }
}
