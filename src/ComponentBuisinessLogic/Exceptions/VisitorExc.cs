using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class VisitorException : Exception
    {

        public VisitorException() : base() { }
        public VisitorException(string message, Exception? innerException) 
            : base(message, innerException) { }

        public VisitorException(string message) 
            : base(message + "Visitor") { }
    }
}
