using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowEditor
{
    class Variable { 
        public Variable(object value, string name)
        {
            Val = value;
            Name = name;
        }

        public object Val { get; set; }
        public string Name { get; set; }

    }
}
