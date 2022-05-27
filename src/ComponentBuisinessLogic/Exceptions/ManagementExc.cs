using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class ManagementException : Exception
    {

        public ManagementException() : base() { }
        public ManagementException(string message, Exception? innerException) 
            : base(message, innerException) { }

        public ManagementException(string message) 
            : base(message + "Management") { }
    }
}
