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
    }
}