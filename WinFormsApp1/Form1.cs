using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // set tipe file default
            ofd.DefaultExt = "bmp";

            ofd.Filter = "image files| *.png; *.jpg; *.bmp; *.jpeg;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                Bitmap bmp = new Bitmap(pictureBox1.Image);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // get image file
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            int r, g, b;

            Color p;

            // get pixel with address (0,0)
            p = bmp.GetPixel(0, 0);
            r = p.R;
            g = p.G;
            b = p.B;

            Debug.WriteLine("(0, 0) : R=" + r);
            Debug.WriteLine("(0, 0) : G=" + g);
            Debug.WriteLine("(0, 0) : B=" + b);

            int m = bmp.Height;
            int n = bmp.Width;

            Color q = bmp.GetPixel(n - 1, m - 1);
            r = q.R;
            g = q.G;
            b = q.B;

            Debug.WriteLine("(" + (n - 1) + "," + (m - 1) + ") : R=" + r);
            Debug.WriteLine("(" + (n - 1) + "," + (m - 1) + ") : G=" + g);
            Debug.WriteLine("(" + (n - 1) + "," + (m - 1) + ") : B=" + b);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // get image from "image form 1"
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            int r, g, b;
            int i;

            // get image specifications
            int m = bmp.Height;
            int n = bmp.Width;

            Color p;

            #region 
            for (int y = 0; y < m - 1; y++)
            {
                for (int x = 0; x < n - 1; x++)
                {
                    // get pixel from (x, y)
                    p = bmp.GetPixel(x, y);
                    r = p.R;
                    g = p.G;
                    b = p.B;

                    i = Convert.ToInt16(0.2989 * r + 0.5870 * g + 0.1141 * b);

                    // convert pixel values(r, g, b) with i
                    bmp.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            // show the result to "image form 2"
            pictureBox2.Image = bmp;
            #endregion
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);

            int r, g, b;
            int i;

            int m = bmp.Height;
            int n = bmp.Width;

            Color p;

            for (int y = 0; y < m - 1; y++)
            {
                for (int x = 0; x < n - 1; x++)
                {
                    p = bmp.GetPixel(x, y);
                    r = p.R;

                    // intensitas ditambah B = 40
                    i = r + 40;

                    if (i > 255)
                    {
                        i = 255;
                    }
                    else if (i < 0)
                    {
                        i = 0;
                    }

                    bmp.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            pictureBox3.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);

            int m = bmp.Height;
            int n = bmp.Width;

            for (int y = 0; y < m - 1; y++)
            {
                for (int x = 0; x < n - 1; x++)
                {
                    Color p = bmp.GetPixel(x, y);

                    p = Color.FromArgb(255, (255 - p.R), (255 - p.G), (255 - p.B));
                    bmp.SetPixel(x, y, p);

                    // int xg = (int)((p.R + p.G + p.B) / 3);
                    // int xi = 255 - xg;
                    // 
                    // Color new_color = Color.FromArgb(xi, xi, xi);
                    // bmp.SetPixel(x, y, new_color);
                }
            }
            pictureBox4.Image = bmp;
        }
    }
}