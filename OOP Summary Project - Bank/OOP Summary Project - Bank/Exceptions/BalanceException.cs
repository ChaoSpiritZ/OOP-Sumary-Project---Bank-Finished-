using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class BalanceException : Exception
    {
        public BalanceException()
        {
        }

        public BalanceException(string message) : base(message)
        {
        }

        public BalanceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BalanceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
