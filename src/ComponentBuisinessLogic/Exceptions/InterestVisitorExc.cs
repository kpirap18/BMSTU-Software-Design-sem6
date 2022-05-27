using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class InterestVisitorException : Exception
    {

        public InterestVisitorException() : base() { }
        public InterestVisitorException(string message, Exception innerException) 
            : base(message, innerException) { }

        public InterestVisitorException(string message) 
            : base(message + "InterestVisitor") {  }
    }
}
