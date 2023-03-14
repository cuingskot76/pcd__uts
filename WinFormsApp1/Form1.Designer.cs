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
            button2 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            button4 = new Button();
            button5 = new Button();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(334, 98);
            button1.Name = "button1";
            button1.Size = new Size(117, 42);
            button1.TabIndex = 0;
            button1.Text = "Pilih Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(334, 150);
            button2.Name = "button2";
            button2.Size = new Size(117, 54);
            button2.TabIndex = 1;
            button2.Text = "Intensitas (0,0) dan (n-1, m-1)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
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
            button3.Location = new Point(334, 210);
            button3.Name = "button3";
            button3.Size = new Size(117, 42);
            button3.TabIndex = 3;
            button3.Text = "Grayscale";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(546, 70);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(257, 268);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(835, 98);
            button4.Name = "button4";
            button4.Size = new Size(108, 42);
            button4.TabIndex = 5;
            button4.Text = "Peningkatan kecerahan";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(835, 181);
            button5.Name = "button5";
            button5.Size = new Size(108, 45);
            button5.TabIndex = 6;
            button5.Text = "Membalik citra";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(1009, 70);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(249, 268);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(546, 391);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(257, 267);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(99, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 9;
            textBox1.Text = "Gambar asal";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(629, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(111, 23);
            textBox2.TabIndex = 10;
            textBox2.Text = "Gambar grayscale";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1068, 28);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(145, 23);
            textBox3.TabIndex = 11;
            textBox3.Text = "Peningkatan kecerahan";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(416, 502);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 12;
            textBox4.Text = "Membalik citra";
            // 
            // button6
            // 
            button6.Location = new Point(334, 258);
            button6.Name = "button6";
            button6.Size = new Size(117, 39);
            button6.TabIndex = 13;
            button6.Text = "Filter Batas";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(334, 303);
            button7.Name = "button7";
            button7.Size = new Size(117, 41);
            button7.TabIndex = 14;
            button7.Text = "Filter Pererataan";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(334, 350);
            button8.Name = "button8";
            button8.Size = new Size(117, 38);
            button8.TabIndex = 15;
            button8.Text = "FIlter Median";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(334, 405);
            button9.Name = "button9";
            button9.Size = new Size(117, 41);
            button9.TabIndex = 16;
            button9.Text = "Ekualisasi Histogram";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(176, 354);
            button10.Name = "button10";
            button10.Size = new Size(117, 34);
            button10.TabIndex = 17;
            button10.Text = "Konvolusi";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(835, 268);
            button11.Name = "button11";
            button11.Size = new Size(108, 45);
            button11.TabIndex = 18;
            button11.Text = "Konversi Citra Biner";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(844, 417);
            button12.Name = "button12";
            button12.Size = new Size(108, 45);
            button12.TabIndex = 19;
            button12.Text = "Deteksi Tepi";
            button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Location = new Point(825, 485);
            button13.Name = "button13";
            button13.Size = new Size(159, 55);
            button13.TabIndex = 20;
            button13.Text = "Cari luas, perimeter, kebulatan, kekompakan";
            button13.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(1009, 391);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(259, 267);
            pictureBox5.TabIndex = 21;
            pictureBox5.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1304, 663);
            Controls.Add(pictureBox5);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(pictureBox2);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Button button3;
        private PictureBox pictureBox2;
        private Button button4;
        private Button button5;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private PictureBox pictureBox5;
    }
}