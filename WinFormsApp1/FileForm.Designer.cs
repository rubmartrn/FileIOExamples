namespace WinFormsApp1
{
    partial class FileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            errorTextBox = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(265, 280);
            button1.Name = "button1";
            button1.Size = new Size(226, 29);
            button1.TabIndex = 0;
            button1.Text = "գրել ֆայլում";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(276, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(270, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 52);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 2;
            label1.Text = "Ֆայլի անունը";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(265, 345);
            button3.Name = "button3";
            button3.Size = new Size(222, 46);
            button3.TabIndex = 4;
            button3.Text = "Կարդալ Ֆայլից";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(276, 98);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(142, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 101);
            label2.Name = "label2";
            label2.Size = new Size(179, 20);
            label2.TabIndex = 7;
            label2.Text = "Ընտրեք գործողությունը";
            label2.Click += label2_Click;
            // 
            // errorTextBox
            // 
            errorTextBox.BackColor = Color.Red;
            errorTextBox.ForeColor = Color.Transparent;
            errorTextBox.Location = new Point(176, 174);
            errorTextBox.Name = "errorTextBox";
            errorTextBox.Size = new Size(379, 27);
            errorTextBox.TabIndex = 8;
            errorTextBox.Visible = false;
            // 
            // FileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(errorTextBox);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "FileForm";
            Text = "FileForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox errorTextBox;
    }
}