using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowEditor
{
    public class Token
    {
        public Token(TokenType type, string str, double prio, bool func = false, List<object>  list = null)
        {
            Type = type;
            String = str;
            Prio = prio;
            IsFunc = func;
            List = list;
        }
        public TokenType Type { get; set; }
        public string String { get; set; }
        public double Prio { get; set; }
        public bool IsFunc { get; set; }
        //is only for values that can't be stored in strings
        public List<object> List { get; set; }

        public void Print(bool WithPrio = false)
        {
            Console.WriteLine(GetString(WithPrio));
        }
        public string GetString(bool WithPrio = false)
        {
            string a = $"{Type.ToString()}: {String}";
            if (WithPrio)
            {
                a += " | " + Prio;
            }
            return a;
        }
        public int GetTreeCallID()
        {
            return int.Parse(String.Replace("TREECALL", ""));
        }
    }

    public enum TokenType
    {
        type,
        id,
        op,
        num,
        str,
        bln,
        list,
        TreeCall,
    }
}
