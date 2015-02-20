using System;
using System.Runtime.Serialization;

namespace go.dnp.dart.core
{
    [Serializable]
    public class ValueOutOfRangeException : Exception
    {
        private string v;
        private int value;

        public ValueOutOfRangeException()
        {
        }

        public ValueOutOfRangeException(string message) : base(message)
        {
        }

        public ValueOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValueOutOfRangeException(int value, string v)
        {
            this.value = value;
            this.v = v;
        }

        protected ValueOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}