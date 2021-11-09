using System;
using System.Runtime.Serialization;

namespace Datalaag.Exceptions
{
    [Serializable]
    public class AdresRepositoryADOException : Exception
    {
        public AdresRepositoryADOException()
        {
        }

        public AdresRepositoryADOException(string message) : base(message)
        {
        }

        public AdresRepositoryADOException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdresRepositoryADOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
