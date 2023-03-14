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

            for (int y = 0; y < m - 1; y++)
            {
                for (int x = 0; x < n - 1; x++)
                {
                    p = bmp.GetPixel(x, y);
                    r = p.R;
                    g = p.G;
                    b = p.B;

                    i = Convert.ToInt16(0.2989 * r + 0.5870 * g + 0.1141 * b);

                    bmp.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            pictureBox2.Image = bmp;
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
                }
            }
            pictureBox4.Image = bmp;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);

            int m = bmp.Height;
            int n = bmp.Width;

            // store 8 address of pixel
            Color T1, T2, T3, T4, T5, T6, T7, T8;

            // store pixel f(x,y)
            Color f;

            // store pixel f(x,y) after filter
            int r;

            // store 8 values of pixel
            int[] p = new int[8];

            int max;
            int min;

            // * Filter Batas
            for (int y = 1; y < m - 1; y++)
            {
                for (int x = 1; x < n - 1; x++)
                {
                    // pixel address f(x, y)
                    f = bmp.GetPixel(x, y);

                    // pixel address f(x, y)
                    T1 = bmp.GetPixel(x + 1, y);
                    T2 = bmp.GetPixel(x + 1, y - 1);
                    T3 = bmp.GetPixel(x, y - 1);
                    T4 = bmp.GetPixel(x - 1, y - 1);
                    T5 = bmp.GetPixel(x - 1, y);
                    T6 = bmp.GetPixel(x - 1, y + 1);
                    T7 = bmp.GetPixel(x, y + 1);
                    T8 = bmp.GetPixel(x + 1, y + 1);

                    // pixel value f(x,y)
                    r = f.R;

                    // store new 8 pixels values
                    p[0] = T1.R;
                    p[1] = T2.R;
                    p[2] = T3.R;
                    p[3] = T4.R;
                    p[4] = T5.R;
                    p[5] = T6.R;
                    p[6] = T7.R;
                    p[7] = T8.R;

                    // set min and max
                    max = p[0];
                    min = p[0];

                    // finding min and max pixel
                    for (int j = 1; j < 8; j++)
                    {
                        if (p[j] > max)
                        {
                            max = p[j];
                        }
                        else
                        {
                            max = max;
                        }
                        if (p[j] < min)
                        {
                            min = p[j];
                        }
                        else
                        {
                            min = min;
                        }
                    }

                    // replace r with min and max
                    if (r < min)
                    {
                        r = min;
                        bmp2.SetPixel(x, y, Color.FromArgb(r, r, r));
                    }
                    else if (r > max)
                    {
                        r = max;
                        bmp2.SetPixel(x, y, Color.FromArgb(r, r, r));
                    }
                    else
                    {
                        r = r;
                        bmp2.SetPixel(x, y, Color.FromArgb(r, r, r));
                    }
                }
            }
            pictureBox2.Image = bmp2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);

            int m = bmp.Height;
            int n = bmp.Width;

            Color T1, T2, T3, T4, T5, T6, T7, T8;

            Color f;

            int r;

            int[] p = new int[8];

            for (int y = 1; y < m - 1; y++)
            {
                for (int x = 1; x < n - 1; x++)
                {
                    f = bmp.GetPixel(x, y);

                    T1 = bmp.GetPixel(x + 1, y);
                    T2 = bmp.GetPixel(x + 1, y - 1);
                    T3 = bmp.GetPixel(x, y - 1);
                    T4 = bmp.GetPixel(x - 1, y - 1);
                    T5 = bmp.GetPixel(x - 1, y);
                    T6 = bmp.GetPixel(x - 1, y + 1);
                    T7 = bmp.GetPixel(x, y + 1);
                    T8 = bmp.GetPixel(x + 1, y + 1);

                    r = f.R;

                    p[0] = T1.R;
                    p[1] = T2.R;
                    p[2] = T3.R;
                    p[3] = T4.R;
                    p[4] = T5.R;
                    p[5] = T6.R;
                    p[6] = T7.R;
                    p[7] = T8.R;

                    // avegare
                    r = Convert.ToInt16((r + p[0] + p[1] + p[2] + p[3] + p[4] + p[5] + p[6] + p[7]) / 9);

                    bmp2.SetPixel(x, y, Color.FromArgb(r, r, r));
                }
            }
            pictureBox2.Image = bmp2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);

            int m = bmp.Height;
            int n = bmp.Width;

            Color T1, T2, T3, T4, T5, T6, T7, T8;

            Color f;

            int r;

            int[] p = new int[8];

            for (int y = 1; y < m - 1; y++)
            {
                for (int x = 1; x < n - 1; x++)
                {
                    f = bmp.GetPixel(x, y);

                    T1 = bmp.GetPixel(x + 1, y);
                    T2 = bmp.GetPixel(x + 1, y - 1);
                    T3 = bmp.GetPixel(x, y - 1);
                    T4 = bmp.GetPixel(x - 1, y - 1);
                    T5 = bmp.GetPixel(x - 1, y);
                    T6 = bmp.GetPixel(x - 1, y + 1);
                    T7 = bmp.GetPixel(x, y + 1);
                    T8 = bmp.GetPixel(x + 1, y + 1);

                    p[0] = T1.R;
                    p[1] = T2.R;
                    p[2] = T3.R;
                    p[3] = T4.R;
                    p[4] = T5.R;
                    p[5] = T6.R;
                    p[6] = T7.R;
                    p[7] = T8.R;

                    // sorting
                    Array.Sort(p);

                    // get the median
                    r = p[4];

                    bmp2.SetPixel(x, y, Color.FromArgb(r, r, r));
                }
            }
            pictureBox2.Image = bmp2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);

            int heigh = bmp.Height;
            int width = bmp.Width;

            // default array size, 0 - 255
            int[] hist = new int[256];

            // array untuk menampung histogram yg keabuannya muncul di citra
            int[] c = new int[256];

            // array untuk menampung a (hasil akhir)
            double[] a = new double[256];

            int t, n;
            int jumlahAras = 0;
            Color P;

            for (int y = 1; y < heigh; y++)
            {
                for (int x = 1; x < width; x++)
                {
                    P = bmp.GetPixel(x, y);
                    t = P.R;

                    // hist[i] => langkah 1
                    for (int i = 0; i < 256; i++)
                    {
                        if (t == i)
                        {
                            hist[i] = hist[i] + 1;
                        }
                    }
                }
            }

            // jumlah aras yg ada dicitra
            for (int j = 0; j < 256; j++)
            {
                Debug.WriteLine("hist[" + j + "] :" + hist[j]);

                if (hist[j] != 0)
                {
                    jumlahAras = jumlahAras + 1;
                }
            }
            Debug.WriteLine("Jumlah aras: " + jumlahAras);

            // c[i] => langkah 2
            for (int j = 0; j < 256; j++)
            {
                for (int k = 0; k <= j; k++)
                {
                    // hanya hist yg intensitasnya ada di citra yg akan diproses
                    if (hist[j] != 0)
                    {
                        c[j] = c[j] + hist[k];
                    }
                }
            }
            for (int j = 0; j < 256; j++)
            {
                Debug.WriteLine("c[" + j + "] :" + c[j]);
            }

            n = heigh * width;
            Debug.WriteLine("n : " + n);

            // a[i] => langkah 3
            for (int j = 0; j < 256; j++)
            {
                if (c[j] != 0)
                {
                    // a[j] = (jumlahAras - 1) * (convert.todouble(c[j]) / (convert.todouble(n)))
                    a[j] = Math.Round(((jumlahAras - 1) * (Convert.ToDouble(c[j]) / (Convert.ToDouble(n)))), 0);
                }
            }
            for (int j = 0; j < 256; j++)
            {
                Debug.WriteLine("a[" + j + "] : " + a[j]);
            }

            // replace with a[i]
            for (int y = 0; y < heigh - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    P = bmp.GetPixel(x, y);
                    t = P.R;

                    for (int j = 0; j < 256; j++)
                    {
                        if (t == j)
                        {
                            t = Convert.ToInt32(a[j]);
                        }
                    }
                    bmp2.SetPixel(x, y, Color.FromArgb(t, t, t));
                }
            }
            pictureBox2.Image = bmp2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);

            int m = bmp.Height;
            int n = bmp.Width;
            int t;
            Color P;
            int m2 = 1;
            int n2 = 1;
            int g = 0;

            int[,] h = new int[4, 4];

            // kernel h (quick mask)
            h[1, 1] = -1;
            h[1, 2] = 0;
            h[1, 3] = -1;
            h[2, 1] = 0;
            h[2, 2] = 4;
            h[2, 3] = 0;
            h[3, 1] = -1;
            h[3, 2] = 0;
            h[3, 3] = -1;

            for (int y = 1; y < m - 1; y++)
            {
                for (int x = 1; x < n - 1; x++)
                {
                    // konvolusi
                    for (int p = -m2; p <= m2; p++)
                    {
                        for (int q = -n2; q <= n2; q++)
                        {
                            P = bmp.GetPixel(x - p, y - q);
                            t = P.R;
                            // rumus konvolusi
                            g = g + h[p + m2 + 1, q + n2 + 1] * t;

                            if (g < 0)
                            {
                                g = 0;
                            }
                            if (g > 255)
                            {
                                g = 255;
                            }
                        }
                    }
                    bmp2.SetPixel(x, y, Color.FromArgb(g, g, g));
                }
            }
            pictureBox2.Image = bmp2;
        }
    }
}