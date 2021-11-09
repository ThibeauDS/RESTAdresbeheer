using System;
using System.Runtime.Serialization;

namespace Domeinlaag.Exceptions
{
    [Serializable]
    public class AdresException : Exception
    {
        public AdresException()
        {
        }

        public AdresException(string message) : base(message)
        {
        }

        public AdresException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdresException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
