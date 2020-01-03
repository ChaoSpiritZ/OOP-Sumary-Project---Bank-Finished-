using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Summary_Project___Bank
{
    class PercentageOutOfRangeException : Exception
    {
        public PercentageOutOfRangeException()
        {
        }

        public PercentageOutOfRangeException(string message) : base(message)
        {
        }

        public PercentageOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PercentageOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
