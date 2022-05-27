using System;

namespace DB
{
    public class AccessException : Exception
    {
        public int UserId { get; }
        public AccessException() : base() { }

        public AccessException(string mes) : base(mes) { }

        public AccessException(string mes, Exception innerException) :
            base(mes, innerException)
        { }

        public AccessException(string mes, int uId) : base(mes)
        {
            UserId = uId;
        }
    }
}
