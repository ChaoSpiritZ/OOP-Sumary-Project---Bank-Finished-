using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class SameAccountException : Exception
    {
        public SameAccountException()
        {
        }

        public SameAccountException(string message) : base(message)
        {
        }

        public SameAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SameAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
