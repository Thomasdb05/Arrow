﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ArrowEditor
{
    public static class Cons
    {
        public static RichTextBox ConsoleBox;
        public static void Write(string txt)
        {
            ConsoleBox.Text += "\n" + txt;
            Console.WriteLine("activated func write to box");
        }
    }
}
