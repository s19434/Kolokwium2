using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KOLOS.Exceptions
{
    public class ArtistDoesNotExistException : Exception
    {
        public ArtistDoesNotExistException()
        {
        }

        public ArtistDoesNotExistException(string message) : base(message)
        {
        }

        public ArtistDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArtistDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
