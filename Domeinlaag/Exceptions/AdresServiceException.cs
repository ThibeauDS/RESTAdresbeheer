using System;
using System.Runtime.Serialization;

namespace Domeinlaag.Exceptions
{
    [Serializable]
    public class AdresServiceException : Exception
    {
        public AdresServiceException()
        {
        }

        public AdresServiceException(string message) : base(message)
        {
        }

        public AdresServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdresServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
