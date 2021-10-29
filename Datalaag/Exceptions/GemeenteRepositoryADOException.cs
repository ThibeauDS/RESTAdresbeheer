using System;
using System.Runtime.Serialization;

namespace Datalaag.Exceptions
{
    [Serializable]
    public class GemeenteRepositoryADOException : Exception
    {
        public GemeenteRepositoryADOException()
        {
        }

        public GemeenteRepositoryADOException(string message) : base(message)
        {
        }

        public GemeenteRepositoryADOException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GemeenteRepositoryADOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
