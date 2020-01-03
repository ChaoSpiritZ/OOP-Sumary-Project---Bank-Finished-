using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class NullCustomerException : Exception
    {
        public NullCustomerException()
        {
        }

        public NullCustomerException(string message) : base(message)
        {
        }

        public NullCustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullCustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
