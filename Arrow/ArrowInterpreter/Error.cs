using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowEditor
{
    static class Error
    {
        public static void Throw(int errornum)
        {
            Console.WriteLine($"ERROR CODE: {errornum}");
            //Environment.Exit(errornum);
        }
    }
}
