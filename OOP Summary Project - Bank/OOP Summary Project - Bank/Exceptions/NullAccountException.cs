using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class NullAccountException : Exception
    {
        public NullAccountException()
        {
        }

        public NullAccountException(string message) : base(message)
        {
        }

        public NullAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
