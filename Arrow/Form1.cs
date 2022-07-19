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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
            PopupSaveFileMenu(false);

            PopupSaveFileNameMenu(false);
            Cons.ConsoleBox = ConsoleTextBox;
            ConsoleTextBox.Text = "";
            Highlighting.KeyWords = Highlighting.ImportKeyWords();
            CodeTextBox.MouseWheel += ZoomIn;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        //File name entry
        void SaveFile(string name)
        {
            string Filepath = $"{Application.LocalUserAppDataPath}\\Projects\\{name}.arr";
            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(Filepath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(CodeTextBox.Text);
                fs.Write(info, 0, info.Length);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(int keyCode);
        public const int KEY_PRESSED = 0x8000;
        public static bool IsKeyDown(Keys key)
        {
            return Convert.ToBoolean(GetKeyState((int)key) & KEY_PRESSED);
        }

        //Menu that asks if user wants to save file
        void PopupSaveFileMenu(bool on)
        {
            SaveFileQuestion.Visible = on;
            SaveFileNo.Visible = on;
            SaveFileYes.Visible = on;
        }

        //Menu that asks how you want to name file
        void PopupSaveFileNameMenu(bool on)
        {
            NameFileQuestion.Visible = on;
            FileNameEnter.Visible = on;
            FileNameEnter.Text = "";
        }

        public void ZoomIn(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if(IsKeyDown(Keys.Control))
                {
                    RichTextBox box = (RichTextBox)sender;
                    box.Font = new Font(box.Font.FontFamily, box.Font.Size + 1, box.Font.Style);
                }
            }
            else
            {
                if (IsKeyDown(Keys.Control))
                {
                    RichTextBox box = (RichTextBox)sender;
                    box.Font = new Font(box.Font.FontFamily, box.Font.Size - 1, box.Font.Style);
                }
            }
        }

        //This is before the user has confirmed wether they want to save the current file or not
        void NewFileStart()
        {
            if (CodeTextBox.Text.Any(x => Char.IsLetter(x)))
            {
                SaveFileQuestionMenu();
            }
        }

        //Actually starting the new file
        void NewFile()
        {
            CodeTextBox.Text = "";
        }

        void OpenFile(string path)
        {
            CodeTextBox.Text = File.ReadAllText(path); 
        }

        void SaveFileQuestionMenu()
        {
            PopupSaveFileMenu(true);
        }

        void SaveFileStart()
        {
            PopupSaveFileNameMenu(true);
        }

        private void SaveFileNo_Click(object sender, EventArgs e)
        {
            PopupSaveFileMenu(false);
        }

        private void SaveFileYes_Click_2(object sender, EventArgs e)
        {
            PopupSaveFileMenu(false);
            SaveFileStart();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            Highlighting.HighLight(CodeTextBox);
        }

        void ColorKeyWords()
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Interpreter.Run(CodeTextBox.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            NewFileStart();
        }

       
        private void FileNameEnter_TextChanged(object sender, EventArgs e)
        {
            if(FileNameEnter.Text.Contains("\n"))
            {
                NameFileQuestion.Visible = false;
                FileNameEnter.Visible = false;

                SaveFile(FileNameEnter.Text.Remove(FileNameEnter.Text.Length-1));
            }
        }

        private void NameFileQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenFileIcon_Click(object sender, EventArgs e)
        {
            DoOpenFile();
        }

        private void DoOpenFile()
        {
            Stream fileStream = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK && (fileStream = openFileDialog1.OpenFile()) != null)
            {
                string fileName = openFileDialog1.FileName;
                OpenFile(fileName);
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            SaveFileStart();
        }

        private void SaveFileText_Click(object sender, EventArgs e)
        {
            SaveFileStart();
        }

        private void NewFileText_Click(object sender, EventArgs e)
        {
            NewFileStart();
        }

        private void OpenFileText_Click(object sender, EventArgs e)
        {
            DoOpenFile();
        }

        private void NewFileText_MouseHover(object sender, EventArgs e)
        {
            Color clr = NewFileText.BackColor;
            NewFileText.BackColor = Color.FromArgb(0, clr.R*2, clr.G, clr.B);
        }
    }
}
