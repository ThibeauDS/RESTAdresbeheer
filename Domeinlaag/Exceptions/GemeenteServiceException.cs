using System;
using System.Runtime.Serialization;

namespace Domeinlaag.Exceptions
{
    [Serializable]
    public class GemeenteServiceException : Exception
    {
        public GemeenteServiceException()
        {
        }

        public GemeenteServiceException(string message) : base(message)
        {
        }

        public GemeenteServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GemeenteServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
