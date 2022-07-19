using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowEditor
{
    static class LibTools
    {
        public static bool CheckIfList(object s, bool ShouldError = true, bool ErrorIfNotList = false)
        {
            if(s.GetType() == typeof(List<string>) || s.GetType() == typeof(string[]) || s.GetType() == typeof(object[]) || s.GetType() == typeof(List<object>))
            {
                if (ShouldError && !ErrorIfNotList)
                {
                    Console.WriteLine("Function does not take list as input value");
                    Error.Throw(0);
                }
                return true;
            }
            if (ShouldError && ErrorIfNotList)
            {
                Console.WriteLine("Function does not take list as input value");
                Error.Throw(0);
            }
            return false;
        }

        public static bool IsNumber(this object value, bool Crash = false, bool CrashIfNum = false)
        {
            bool isnum = value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
            if(!isnum && Crash)
            {
                Console.WriteLine("Didnt input number");
                Error.Throw(0);
                return false;
            }
            if (isnum && CrashIfNum && Crash)
            {
                Console.WriteLine("Cant input number here");
                Error.Throw(0);
                return false;
            }
            return isnum;
        }
    }
}
