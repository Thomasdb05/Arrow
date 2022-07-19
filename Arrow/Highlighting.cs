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
    public static class Highlighting
    {
        public static Color DefaultTextColor = Color.White;
        public static Color StringColor = Color.Bisque;
        public struct KeyWord
        {
            public KeyWord(Color color, string word)
            {
                Color = color;
                Word = word;
            }
            public Color Color { get; set; }
            public string Word { get; set; }
        }

        public static List<KeyWord> KeyWords = new List<KeyWord>();

        public static Color HexToColor(string hex)
        {
            return System.Drawing.ColorTranslator.FromHtml(hex);
        }

        public static List<KeyWord> ImportKeyWords()
        {
            List<KeyWord> ImportedKeyWords = new List<KeyWord>();
            Color CurrentColor = Color.Black;
            string[] lines = System.IO.File.ReadAllLines(Application.LocalUserAppDataPath + @"\Config\Colors.config");
            for(int i = 0; i < lines.Length; i++)
            {
                if(lines[i][0] == '#')
                {
                    CurrentColor = HexToColor(lines[i]);
                }
                else
                {
                    ImportedKeyWords.Add(new KeyWord(CurrentColor, lines[i]));
                }
            }
            return ImportedKeyWords;
        }
        public static void HighLight(RichTextBox box)
        {
            ResetBoxColor(box);
            foreach(KeyWord keyword in KeyWords)
            {
                CheckKeyword(keyword.Word, keyword.Color, box);
            }
            ColorStrings(box);
        }

        static void ResetBoxColor(RichTextBox box)
        {
            int selectstart = box.SelectionStart;
            box.Select(0, box.Text.Length);
            box.SelectionColor = DefaultTextColor;
            box.Select(selectstart, 0);
            box.SelectionColor = DefaultTextColor;
        }

        static void ColorStrings(RichTextBox box)
        {
            if (box.Text.Contains("\""))
            {
                int selectStart = box.SelectionStart;
                List<int> AllIndexes = box.Text.AllIndexesOf("\"");
                if (AllIndexes.Count > 1)
                {
                    for (int i = 0; i < AllIndexes.Count; i += 2)
                    {
                        box.Select(AllIndexes[i], (AllIndexes[i + 1] - AllIndexes[i]) + 1);
                        box.SelectionColor = StringColor;
                        box.Select(selectStart, 0);
                        box.SelectionColor = Color.Black;
                        if (i >= AllIndexes.Count - 3)
                        {
                            return;
                        }
                    }
                }
            }
        }

        static void CheckKeyword(string word, Color color, RichTextBox box)
        {
            if (box.Text.Contains(word))
            {
                int index = -1;
                int selectStart = box.SelectionStart;

                while ((index = box.Text.IndexOf(word, (index + 1))) != -1)
                {
                    //check for isolation
                    bool IsIsolated = false;
                    if (word.Any(x => !char.IsLetter(x)))
                    {
                        IsIsolated = true;
                    }
                    else
                    {
                        if (index == 0 || !char.IsLetter(box.Text[index - 1]))
                        {
                            if (index + word.Length == box.Text.Length || !Char.IsLetter(box.Text[index + word.Length]))
                            {
                                IsIsolated = true;
                            }
                        }
                    }

                    if (IsIsolated)
                    {
                        box.Select(index, word.Length);
                        box.SelectionColor = color;
                        box.Select(selectStart, 0);
                        box.SelectionColor = Color.Black;
                    }
                }
            }
        }
    }
}
