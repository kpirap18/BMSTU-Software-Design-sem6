using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class HotelException : Exception
    {

        public HotelException() : base() { }
        public HotelException(string message, Exception? innerException) 
            : base(message, innerException) { }

        public HotelException(string message) 
            : base(message + "Hotel")  {   }
    }
}
