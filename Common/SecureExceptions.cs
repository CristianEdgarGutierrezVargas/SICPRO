using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SecureExceptions : ApplicationException
    {
        public SecureExceptions(string mensaje, Exception original) : base(mensaje, original)
        {
        }

        public SecureExceptions(string mensaje) : base(mensaje)
        {
        }
    }
}
