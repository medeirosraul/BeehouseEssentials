using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Beehouse.Essentials.Logging
{
    public static class LogExtensions
    {
        public static void Log(this object o, string message)
        {
            string t = o.GetType().FullName;
            Debug.WriteLine($"{t} >> {message}");
        }
    }
}
