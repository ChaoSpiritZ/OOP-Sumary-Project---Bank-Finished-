using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class UnpositiveAmountException : Exception
    {
        public UnpositiveAmountException()
        {
        }

        public UnpositiveAmountException(string message) : base(message)
        {
        }

        public UnpositiveAmountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnpositiveAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
