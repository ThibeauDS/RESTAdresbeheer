using System;
using System.Runtime.Serialization;

namespace Domeinlaag.Exceptions
{
    [Serializable]
    public class StraatException : Exception
    {
        public StraatException()
        {
        }

        public StraatException(string message) : base(message)
        {
        }

        public StraatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StraatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
