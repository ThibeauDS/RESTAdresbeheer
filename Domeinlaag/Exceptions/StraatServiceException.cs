using System;
using System.Runtime.Serialization;

namespace Domeinlaag.Exceptions
{
    [Serializable]
    public class StraatServiceException : Exception
    {
        public StraatServiceException()
        {
        }

        public StraatServiceException(string message) : base(message)
        {
        }

        public StraatServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StraatServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
