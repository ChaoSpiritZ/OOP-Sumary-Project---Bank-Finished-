using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class CustomerAlreadyExistsException : Exception
    {
        public CustomerAlreadyExistsException()
        {
        }

        public CustomerAlreadyExistsException(string message) : base(message)
        {
        }

        public CustomerAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
