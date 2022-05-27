using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class AvailabledealException : Exception
    {

        public AvailabledealException() : base() { }
        public AvailabledealException(string message, Exception? innerException) 
            : base(message, innerException) { }

        public AvailabledealException(string message) 
            : base(message + "Availabledeal") { }
    }
}

