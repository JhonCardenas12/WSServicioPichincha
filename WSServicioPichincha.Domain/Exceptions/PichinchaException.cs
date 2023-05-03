using System.Runtime.Serialization;


namespace WSServicioPichincha.Domain.Exceptions
{
    public class PichinchaException : Exception
    {
        public PichinchaException()
        {

        }
        public PichinchaException(string message) : base(message) { }
        public PichinchaException(string message, Exception inner) : base(message, inner) { }

        public PichinchaException(SerializationInfo info, StreamingContext contex) : base(info, contex) { }
    }
}
