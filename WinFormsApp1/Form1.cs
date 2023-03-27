using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Get picture
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


        // Grayscale
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {

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

        // Button-3
        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(pictureBox2.Image);
            int h = bmp2.Height;
            int w = bmp2.Width;
            Color p;
            double N = h * w;

            int[] hist = new int[256]; // untuk histogram citra grayscale
            double[] w1 = new double[256]; // weight/ bobot background
            double[] w2 = new double[256]; // weight/ bobot foreground
            double[] m1 = new double[256]; // mean backgraound
            double[] m2 = new double[256]; // mean foreground
            double[] v1 = new double[256]; // variance background
            double[] v2 = new double[256]; // variance foreground
            double[] WCV = new double[256]; // Within Class Variance
            double[] prob = new double[256];
            double w2_ = 0;
            double m2_ = 0;
            double m1_ = 0;
            double w1_ = 0;
            double v1_ = 0;
            double v2_ = 0;
            double WCV_ = 0;

            // get histogram citra grayscale
            #region get histogram citra grayscale
            int intensitas;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    p = bmp2.GetPixel(x, y);
                    intensitas = p.B;

                    for (int j = 0; j < 256; j++)
                    {
                        if (intensitas == j)
                        {
                            hist[j] = hist[j] + 1;
                            break;
                        }
                    }
                }
            }
            #endregion

            // get probabilitas intensitas value
            #region get probabilitas
            for (int l = 0; l < 256; l++)
            {
                prob[l] = hist[l] / N;
            }
            #endregion

            // get weight background and weight foreground value
            #region get weight background and foreground value
            for (int l = 0; l < 256; l++)
            {
                w1_ = 0;
                for (int m = l; m > 0; m--)
                {
                    w1_ = w1_ + prob[m];
                }
                w1[l] = w1_;
            }
            for (int l = 0; l < 256; l++)
            {
                w2_ = 0;
                for (int m = l + 1; m < 256; m++)
                {
                    w2_ = w2_ + prob[m];
                }
                w2[l] = w2_;
            }
            #endregion

            // get mean background and mean foreground
            #region get mean background and mean foreground
            for (int l = 0; l < 256; l++)
            {
                w1_ = 0;
                m1_ = 0;
                for (int m = l; m > 0; m--)
                {
                    w1_ = w1_ + hist[m];
                }
                for (int n = l; n > 0; n--)
                {
                    m1_ = (m1_ + (n * hist[n]));
                }
                if (w1_ == 0)
                {
                    m1[l] = 0;
                }
                else
                {
                    m1[l] = m1_ / w1_;
                }
            }

            for (int l = 0; l < 256; l++)
            {
                w2_ = 0;
                m2_ = 0;

                for (int m = l + 1; m < 256; m++)
                {
                    w2_ = w2_ + hist[m];
                }
                for (int n = l + 1; n < 256; n++)
                {
                    m2_ = (m2_ + (n * hist[n]));
                }
                if (w2_ == 0)
                {
                    m2[l] = 0;
                }
                else
                {
                    m2[l] = m2_ / w2_;
                }
            }
            #endregion

            // get variance background and foreground
            #region get variance background and foreground
            for (int l = 0; l < 256; l++)
            {
                w2_ = 0;
                v2_ = 0;

                for (int m = l + 1; m < 256; m++)
                {
                    v2_ = v2_ + Math.Pow((m - m2[m]), 2) * hist[m];
                }
                for (int n = l + 1; n < 256; n++)
                {
                    w2_ = w2_ + hist[n];
                }
                if (w2_ == 0)
                {
                    v2[l] = 0;
                }
                else
                {
                    v2[l] = v2_ / w2_;
                }
            }

            for (int l = 0; l < 256; l++)
            {
                w1_ = 0;
                v1_ = 0;
                for (int m = l; m > 0; m--)
                {
                    v1_ = v1_ + Math.Pow((m - m1[m]), 2) * hist[m];
                }
                for (int n = l; n > 0; n--)
                {
                    w1_ = w1_ + hist[n];
                }
                if (w1_ == 0)
                {
                    v1[l] = 0;
                }
                else
                {
                    v1[l] = v1_ / w1_;
                }
            }
            #endregion

            // get nilai WCV and WCV terkecil
            #region mencari nilai WCV dan WCV terkecil
            for (int l = 0; l < 256; l++)
            {
                WCV[l] = w1[l] * v1[l] + w2[l] * v2[l];
                Debug.WriteLine("WCV[" + l + "] : " + WCV[l]);
            }

            double minWCV = WCV[1];
            for (int l = 0; l < 256; l++)
            {
                if (minWCV < WCV[l])
                {
                    minWCV = minWCV;
                }
                else
                {
                    minWCV = WCV[l];
                }

            }
            Debug.WriteLine("minimal WCV : " + minWCV);
            #endregion

            // nilai treshold diambil dari nilai index intensitas histogram gryscale yang mempunyai nilai WCV terkecil
            int threshold = 0;
            for (int l = 0; l < 256; l++)
            {
                if (minWCV == WCV[l])
                {
                    threshold = 1;
                }
            }
            Debug.WriteLine("Threshold A: " + threshold);

            // thresholding ==> konversi citra biner
            // menggunakan nilai threshold yand didapat
            #region thresholding
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    p = bmp2.GetPixel(x, y);
                    intensitas = p.B;

                    if (intensitas < threshold)
                    {
                        bmp2.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        bmp2.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pictureBox4.Image = bmp2;
            #endregion
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
