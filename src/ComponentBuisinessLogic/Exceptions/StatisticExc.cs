using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class StatisticException : Exception
    {
        public StatisticException() : base() { }
        public StatisticException(string message, Exception? innerException) 
            : base(message, innerException) { }

        public StatisticException(string message)
            : base(message + "Statistic") { }

    }
}
