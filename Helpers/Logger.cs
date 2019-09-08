using System;
using System.Collections.Generic;
using System.Text;

namespace FH4RP.Helpers
{
    public static class Logger
    {
        public static void Log(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
        }
    }
}
