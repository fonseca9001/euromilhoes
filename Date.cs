using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace euromilhoes
{
    class dateOperations
    {
       public static DateTime passTime()
        {
            //return system date plus 1 day
            return DateTime.Now.AddDays(1);
        }
    }
}