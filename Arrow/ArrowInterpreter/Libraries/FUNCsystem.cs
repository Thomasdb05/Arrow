using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace ArrowEditor
{
    public static class FUNCsystem
    {
        public static void print(object value)
        {
            if (LibTools.CheckIfList(value, false))
            {
                string s = "";
                object[] list = (object[])value;
                for(int i = 0; i < list.Length; i++)
                {
                    s += list[i].ToString();
                    if (i != list.Length - 1)
                    {
                        s += ", ";
                    }
                }
                Cons.Write(s);
                Console.WriteLine(s);
                return;
            }
            Cons.Write(value.ToString());
            Console.WriteLine(value.ToString());
        }

        public static List<object> sortlst(object value)
        {
            if (LibTools.CheckIfList(value, true, true))
            {
                object[] list = (object[])value;
                List<float> sorted = new List<float>();
                for (int i = 0; i < list.Length; i++)
                {
                    if(list[i].IsNumber(true))
                    {
                        sorted.Add(float.Parse(list[i].ToString()));
                    }
                }
                sorted.Sort();
                return sorted.Cast<object>().ToList();
            }
            return null;
        }

        public static double cos(object value)
        {
            LibTools.CheckIfList(value);

            if (value.IsNumber(true))
            {
                return Math.Cos(double.Parse(value.ToString()));
            }
            return -1;
        }
        public static string readline()
        {
            return Console.ReadLine();
        }
        //input year for years, hour for hours, minute for minutes, milli for milliseconds
        public static int gettime(object value)
        {
            string val = value.ToString();
            switch(val)
            {
                case "year":
                    return DateTime.Now.Year;
                    break;
                case "hour":
                    return DateTime.Now.Hour;
                    break;
                case "minute":
                    return DateTime.Now.Minute;
                    break;
                case "milli":
                    return DateTime.Now.Millisecond;
                    break;
                default:
                    return -1;

            }
        }

        public static int asint(object value)
        {
            LibTools.CheckIfList(value);
            string val = value.ToString();
            return int.Parse(val);
        }

        public static float asflt(object value)
        {
            LibTools.CheckIfList(value);
            string val = value.ToString();
            return float.Parse(val);
        }

        public static string asstr(object value)
        {
            return value.ToString();
        }

        public static int length(object value)
        {
            if (LibTools.CheckIfList(value, false))
            {
                return ((object[])value).Length;
            }
            return value.ToString().Length;         
        }

        public static string toupper(object value)
        {
            LibTools.CheckIfList(value);

            return value.ToString().ToUpper();
        }
        public static string tolower(object value)
        {
            LibTools.CheckIfList(value);

            return value.ToString().ToLower();
        }

        public static string open(object value)
        {
            LibTools.CheckIfList(value);

            return File.ReadAllText(value.ToString());
        }

        public static void sleep(object value)
        {
            LibTools.CheckIfList(value);

            string val = value.ToString();
            //TEMP: also works when inputting string now
            if (int.TryParse(val, out int Value))
            {
                Thread.Sleep(Value);
                return;
            }
            Console.WriteLine($"Can't convert {val.ToString()} to number");
            Error.Throw(0);
        }

    }
}
