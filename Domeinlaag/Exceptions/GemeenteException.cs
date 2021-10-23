using System;
using System.Runtime.Serialization;

namespace Domeinlaag.Exceptions
{
    [Serializable]
    public class GemeenteException : Exception
    {
        public GemeenteException()
        {
        }

        public GemeenteException(string message) : base(message)
        {
        }

        public GemeenteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GemeenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
