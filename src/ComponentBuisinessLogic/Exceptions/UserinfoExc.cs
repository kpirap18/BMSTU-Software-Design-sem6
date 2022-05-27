using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class UserinfoException : Exception
    {

        public UserinfoException() : base() { }
        public UserinfoException(string message, Exception? innerException) 
            : base(message, innerException) { }

        public UserinfoException(string message) 
            : base(message + "Userinfo") { }
    }
}
