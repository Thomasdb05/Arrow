
namespace ArrowEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.SaveFileText = new System.Windows.Forms.Button();
            this.OpenFileText = new System.Windows.Forms.Button();
            this.NewFileText = new System.Windows.Forms.Button();
            this.SettingsWheel = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.SaveFileIcon = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.OpenFileIcon = new System.Windows.Forms.PictureBox();
            this.NewFileIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.FileNameEnter = new System.Windows.Forms.RichTextBox();
            this.NameFileQuestion = new System.Windows.Forms.RichTextBox();
            this.SaveFileYes = new System.Windows.Forms.Button();
            this.SaveFileNo = new System.Windows.Forms.Button();
            this.SaveFileQuestion = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.ConsoleTextBox = new System.Windows.Forms.RichTextBox();
            this.CodeTextBox = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveFileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewFileIcon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel2.Controls.Add(this.SaveFileText);
            this.panel2.Controls.Add(this.OpenFileText);
            this.panel2.Controls.Add(this.NewFileText);
            this.panel2.Controls.Add(this.SettingsWheel);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.SaveFileIcon);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.OpenFileIcon);
            this.panel2.Controls.Add(this.NewFileIcon);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(-1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 801);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // SaveFileText
            // 
            this.SaveFileText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveFileText.BackgroundImage")));
            this.SaveFileText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveFileText.Font = new System.Drawing.Font("Junegull", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveFileText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.SaveFileText.Location = new System.Drawing.Point(106, 410);
            this.SaveFileText.Margin = new System.Windows.Forms.Padding(0);
            this.SaveFileText.Name = "SaveFileText";
            this.SaveFileText.Size = new System.Drawing.Size(110, 58);
            this.SaveFileText.TabIndex = 10;
            this.SaveFileText.Text = "SAVE FILE";
            this.SaveFileText.UseVisualStyleBackColor = true;
            this.SaveFileText.Click += new System.EventHandler(this.SaveFileText_Click);
            // 
            // OpenFileText
            // 
            this.OpenFileText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenFileText.BackgroundImage")));
            this.OpenFileText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileText.Font = new System.Drawing.Font("Junegull", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenFileText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.OpenFileText.Location = new System.Drawing.Point(109, 279);
            this.OpenFileText.Margin = new System.Windows.Forms.Padding(0);
            this.OpenFileText.Name = "OpenFileText";
            this.OpenFileText.Size = new System.Drawing.Size(110, 58);
            this.OpenFileText.TabIndex = 9;
            this.OpenFileText.Text = "OPEN FILE";
            this.OpenFileText.UseVisualStyleBackColor = true;
            this.OpenFileText.Click += new System.EventHandler(this.OpenFileText_Click);
            // 
            // NewFileText
            // 
            this.NewFileText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NewFileText.BackgroundImage")));
            this.NewFileText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewFileText.Font = new System.Drawing.Font("Junegull", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewFileText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.NewFileText.Location = new System.Drawing.Point(109, 162);
            this.NewFileText.Margin = new System.Windows.Forms.Padding(0);
            this.NewFileText.Name = "NewFileText";
            this.NewFileText.Size = new System.Drawing.Size(110, 58);
            this.NewFileText.TabIndex = 5;
            this.NewFileText.Text = "NEW FILE";
            this.NewFileText.UseVisualStyleBackColor = true;
            this.NewFileText.Click += new System.EventHandler(this.NewFileText_Click);
            this.NewFileText.MouseHover += new System.EventHandler(this.NewFileText_MouseHover);
            // 
            // SettingsWheel
            // 
            this.SettingsWheel.Image = global::ArrowEditor.Properties.Resources.SettingWheel;
            this.SettingsWheel.Location = new System.Drawing.Point(0, 728);
            this.SettingsWheel.Name = "SettingsWheel";
            this.SettingsWheel.Size = new System.Drawing.Size(73, 73);
            this.SettingsWheel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SettingsWheel.TabIndex = 5;
            this.SettingsWheel.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.panel6.Location = new System.Drawing.Point(47, 377);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(150, 2);
            this.panel6.TabIndex = 8;
            // 
            // SaveFileIcon
            // 
            this.SaveFileIcon.Image = global::ArrowEditor.Properties.Resources.ArrowSaveFileIcon3;
            this.SaveFileIcon.Location = new System.Drawing.Point(19, 369);
            this.SaveFileIcon.Name = "SaveFileIcon";
            this.SaveFileIcon.Size = new System.Drawing.Size(84, 119);
            this.SaveFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SaveFileIcon.TabIndex = 6;
            this.SaveFileIcon.TabStop = false;
            this.SaveFileIcon.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.panel5.Location = new System.Drawing.Point(47, 252);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(150, 2);
            this.panel5.TabIndex = 5;
            // 
            // OpenFileIcon
            // 
            this.OpenFileIcon.Image = global::ArrowEditor.Properties.Resources.ArrowOpenFileIcon1;
            this.OpenFileIcon.Location = new System.Drawing.Point(19, 244);
            this.OpenFileIcon.Name = "OpenFileIcon";
            this.OpenFileIcon.Size = new System.Drawing.Size(84, 119);
            this.OpenFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OpenFileIcon.TabIndex = 3;
            this.OpenFileIcon.TabStop = false;
            this.OpenFileIcon.Click += new System.EventHandler(this.OpenFileIcon_Click);
            // 
            // NewFileIcon
            // 
            this.NewFileIcon.Image = global::ArrowEditor.Properties.Resources.ArrowNewFileIcon;
            this.NewFileIcon.Location = new System.Drawing.Point(19, 128);
            this.NewFileIcon.Name = "NewFileIcon";
            this.NewFileIcon.Size = new System.Drawing.Size(84, 119);
            this.NewFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NewFileIcon.TabIndex = 1;
            this.NewFileIcon.TabStop = false;
            this.NewFileIcon.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1388, 122);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(31, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(36)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1031, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 103);
            this.button1.TabIndex = 0;
            this.button1.Text = "PLAY";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.panel4.Controls.Add(this.FileNameEnter);
            this.panel4.Controls.Add(this.NameFileQuestion);
            this.panel4.Controls.Add(this.SaveFileYes);
            this.panel4.Controls.Add(this.SaveFileNo);
            this.panel4.Controls.Add(this.SaveFileQuestion);
            this.panel4.Controls.Add(this.richTextBox5);
            this.panel4.Controls.Add(this.ConsoleTextBox);
            this.panel4.Controls.Add(this.CodeTextBox);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(235, 121);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1152, 681);
            this.panel4.TabIndex = 3;
            // 
            // FileNameEnter
            // 
            this.FileNameEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(36)))));
            this.FileNameEnter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileNameEnter.Font = new System.Drawing.Font("Junegull", 20.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FileNameEnter.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.FileNameEnter.Location = new System.Drawing.Point(281, 260);
            this.FileNameEnter.Name = "FileNameEnter";
            this.FileNameEnter.Size = new System.Drawing.Size(229, 57);
            this.FileNameEnter.TabIndex = 8;
            this.FileNameEnter.Text = "";
            this.FileNameEnter.TextChanged += new System.EventHandler(this.FileNameEnter_TextChanged);
            // 
            // NameFileQuestion
            // 
            this.NameFileQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.NameFileQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameFileQuestion.Font = new System.Drawing.Font("Junegull", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameFileQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.NameFileQuestion.Location = new System.Drawing.Point(273, 213);
            this.NameFileQuestion.Name = "NameFileQuestion";
            this.NameFileQuestion.Size = new System.Drawing.Size(245, 128);
            this.NameFileQuestion.TabIndex = 7;
            this.NameFileQuestion.Text = "            Name file:";
            this.NameFileQuestion.TextChanged += new System.EventHandler(this.NameFileQuestion_TextChanged);
            // 
            // SaveFileYes
            // 
            this.SaveFileYes.FlatAppearance.BorderSize = 0;
            this.SaveFileYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveFileYes.Font = new System.Drawing.Font("Junegull", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveFileYes.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.SaveFileYes.Location = new System.Drawing.Point(425, 290);
            this.SaveFileYes.Name = "SaveFileYes";
            this.SaveFileYes.Size = new System.Drawing.Size(75, 36);
            this.SaveFileYes.TabIndex = 6;
            this.SaveFileYes.Text = "Yes";
            this.SaveFileYes.UseVisualStyleBackColor = true;
            this.SaveFileYes.Click += new System.EventHandler(this.SaveFileYes_Click_2);
            // 
            // SaveFileNo
            // 
            this.SaveFileNo.FlatAppearance.BorderSize = 0;
            this.SaveFileNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveFileNo.Font = new System.Drawing.Font("Junegull", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveFileNo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.SaveFileNo.Location = new System.Drawing.Point(290, 290);
            this.SaveFileNo.Name = "SaveFileNo";
            this.SaveFileNo.Size = new System.Drawing.Size(75, 36);
            this.SaveFileNo.TabIndex = 5;
            this.SaveFileNo.Text = "No";
            this.SaveFileNo.UseVisualStyleBackColor = true;
            this.SaveFileNo.Click += new System.EventHandler(this.SaveFileNo_Click);
            // 
            // SaveFileQuestion
            // 
            this.SaveFileQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.SaveFileQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SaveFileQuestion.Font = new System.Drawing.Font("Junegull", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveFileQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.SaveFileQuestion.Location = new System.Drawing.Point(273, 213);
            this.SaveFileQuestion.Name = "SaveFileQuestion";
            this.SaveFileQuestion.Size = new System.Drawing.Size(245, 128);
            this.SaveFileQuestion.TabIndex = 4;
            this.SaveFileQuestion.Text = "            Save file?";
            // 
            // richTextBox5
            // 
            this.richTextBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(36)))));
            this.richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox5.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox5.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.richTextBox5.Location = new System.Drawing.Point(765, 612);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox5.Size = new System.Drawing.Size(387, 69);
            this.richTextBox5.TabIndex = 3;
            this.richTextBox5.Text = "Input text";
            this.richTextBox5.WordWrap = false;
            this.richTextBox5.TextChanged += new System.EventHandler(this.richTextBox5_TextChanged);
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ConsoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.ConsoleTextBox.Location = new System.Drawing.Point(765, 42);
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ConsoleTextBox.Size = new System.Drawing.Size(387, 575);
            this.ConsoleTextBox.TabIndex = 2;
            this.ConsoleTextBox.Text = "Example text";
            this.ConsoleTextBox.WordWrap = false;
            this.ConsoleTextBox.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.CodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CodeTextBox.Font = new System.Drawing.Font("ADAM.CG PRO", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CodeTextBox.ForeColor = System.Drawing.Color.White;
            this.CodeTextBox.Location = new System.Drawing.Point(86, 119);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(1075, 556);
            this.CodeTextBox.TabIndex = 1;
            this.CodeTextBox.Text = "str name = \"john\"]";
            this.CodeTextBox.WordWrap = false;
            this.CodeTextBox.TextChanged += new System.EventHandler(this.CodeTextBox_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(36)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1152, 42);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ArrowEditor.Properties.Resources.ArrowPlayButton;
            this.pictureBox2.Location = new System.Drawing.Point(1157, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(230, 114);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "arrow files (*.arr)|*.arr|All files (*.*)|*.*\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1387, 802);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveFileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewFileIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox CodeTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox NewFileIcon;
        private System.Windows.Forms.PictureBox OpenFileIcon;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox ConsoleTextBox;
        private System.Windows.Forms.Button SaveFileYes;
        private System.Windows.Forms.Button SaveFileNo;
        private System.Windows.Forms.RichTextBox SaveFileQuestion;
        private System.Windows.Forms.RichTextBox FileNameEnter;
        private System.Windows.Forms.RichTextBox NameFileQuestion;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox SaveFileIcon;
        private System.Windows.Forms.PictureBox SettingsWheel;
        private System.Windows.Forms.Button SaveFileText;
        private System.Windows.Forms.Button OpenFileText;
        private System.Windows.Forms.Button NewFileText;
    }
}

