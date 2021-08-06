using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6
{
    class SaldoException : Exception
    {
        public SaldoException()
        {
        }

        public SaldoException(string message) : base(message)
        {
        }

        public SaldoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaldoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
