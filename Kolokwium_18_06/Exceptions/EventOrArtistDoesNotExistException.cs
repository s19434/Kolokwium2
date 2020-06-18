using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KOLOS.Exceptions
{
    public class EventOrArtistDoesNotExistException : Exception
    {
        public EventOrArtistDoesNotExistException()
        {
        }

        public EventOrArtistDoesNotExistException(string message) : base(message)
        {
        }

        public EventOrArtistDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EventOrArtistDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
