using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class NotSameCustomerException : Exception
    {
        public NotSameCustomerException()
        {
        }

        public NotSameCustomerException(string message) : base(message)
        {
        }

        public NotSameCustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSameCustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
