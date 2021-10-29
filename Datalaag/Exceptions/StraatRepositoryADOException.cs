using System;
using System.Runtime.Serialization;

namespace Datalaag.Exceptions
{
    [Serializable]
    public class StraatRepositoryADOException : Exception
    {
        public StraatRepositoryADOException()
        {
        }

        public StraatRepositoryADOException(string message) : base(message)
        {
        }

        public StraatRepositoryADOException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StraatRepositoryADOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
