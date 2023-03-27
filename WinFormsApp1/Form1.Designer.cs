namespace WinFormsApp1
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
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox4 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button13 = new Button();
            textBox4 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(99, 367);
            button1.Name = "button1";
            button1.Size = new Size(117, 42);
            button1.TabIndex = 0;
            button1.Text = "Pilih Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(292, 268);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(457, 375);
            button3.Name = "button3";
            button3.Size = new Size(117, 42);
            button3.TabIndex = 3;
            button3.Text = "Grayscale";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(388, 70);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(257, 268);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(716, 71);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(257, 267);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(99, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 9;
            textBox1.Text = "Citra Input";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(428, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(111, 23);
            textBox2.TabIndex = 10;
            textBox2.Text = "Citra Grayscale";
            // 
            // button13
            // 
            button13.Location = new Point(716, 361);
            button13.Name = "button13";
            button13.Size = new Size(159, 70);
            button13.TabIndex = 20;
            button13.Text = "Citra Biner dengan Nilai Treshold dicari menggunakan Otsu";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(764, 28);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(111, 23);
            textBox4.TabIndex = 21;
            textBox4.Text = "Citra Biner";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1304, 663);
            Controls.Add(textBox4);
            Controls.Add(button13);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Button button3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button13;
        private TextBox textBox4;
    }
}