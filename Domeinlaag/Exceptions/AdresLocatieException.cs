using System;
using System.Runtime.Serialization;

namespace Domeinlaag.Exceptions
{
    [Serializable]
    public class AdresLocatieException : Exception
    {
        public AdresLocatieException()
        {
        }

        public AdresLocatieException(string message) : base(message)
        {
        }

        public AdresLocatieException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdresLocatieException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
