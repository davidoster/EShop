using System;
using System.Runtime.Serialization;

namespace EFProjectCodeFirst1.Services
{
    [Serializable]
    internal class DBServerConnectionErrorException : Exception
    {
        public DBServerConnectionErrorException()
        {
        }

        public DBServerConnectionErrorException(string message) : base(message)
        {
        }

        public DBServerConnectionErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DBServerConnectionErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}