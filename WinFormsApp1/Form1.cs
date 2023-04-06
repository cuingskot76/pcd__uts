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

                    if (intensitas < 160)
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

        private void button2_Click(object sender, EventArgs e)
        {
            int[] histogramObjek = new int[256]; //histogram grayscale
            Bitmap bmp5 = new Bitmap(pictureBox2.Image);//image grayscale
            Bitmap bmp6 = new Bitmap(pictureBox4.Image);//image biner
            int height = bmp5.Height;
            int width = bmp5.Width;
            Color h;
            Color h2;
            // GLCM skala 16 x 16 supaya matrik GLCM tidak terlalu besar dimensinya
            // akan mempengaruhi waktu eksekusi
            #region
            int intensitas5 = 0;
            int[,] matrikImage = new int[height, width];//matrik image yang sudah ternormalisasi, isi intensitas gray 0-15
            double[,] matrikCooccurrence = new double[16, 16]; // matriks co-occurrence
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    h = bmp6.GetPixel(x, y); //biner
                    h2 = bmp5.GetPixel(x, y); //grayscale
                    if (h.R == 255)
                    {
                        intensitas5 = h2.B;
                        if (intensitas5 >= 0 && intensitas5 <= 15)
                        {
                            intensitas5 = 0;
                        }
                        if (intensitas5 >= 16 && intensitas5 <= 31)
                        {
                            intensitas5 = 1;
                        }
                        if (intensitas5 >= 32 && intensitas5 <= 47)
                        {
                            intensitas5 = 2;
                        }
                        if (intensitas5 >= 48 && intensitas5 <= 63)
                        {
                            intensitas5 = 3;
                        }
                        if (intensitas5 >= 64 && intensitas5 <= 79)
                        {
                            intensitas5 = 4;
                        }
                        if (intensitas5 >= 80 && intensitas5 <= 95)
                        {
                            intensitas5 = 5;
                        }
                        if (intensitas5 >= 96 && intensitas5 <= 111)
                        {
                            intensitas5 = 6;
                        }
                        if (intensitas5 >= 112 && intensitas5 <= 127)
                        {
                            intensitas5 = 7;
                        }
                        if (intensitas5 >= 128 && intensitas5 <= 143)
                        {
                            intensitas5 = 8;
                        }
                        if (intensitas5 >= 144 && intensitas5 <= 159)
                        {
                            intensitas5 = 9;
                        }
                        if (intensitas5 >= 160 && intensitas5 <= 175)
                        {
                            intensitas5 = 10;
                        }
                        if (intensitas5 >= 176 && intensitas5 <= 191)
                        {
                            intensitas5 = 11;
                        }
                        if (intensitas5 >= 192 && intensitas5 <= 207)
                        {
                            intensitas5 = 12;
                        }
                        if (intensitas5 >= 208 && intensitas5 <= 223)
                        {
                            intensitas5 = 13;
                        }
                        if (intensitas5 >= 224 && intensitas5 <= 239)
                        {
                            intensitas5 = 14;
                        }
                        if (intensitas5 >= 240 && intensitas5 <= 255)
                        {
                            intensitas5 = 15;
                        }
                        matrikImage[y, x] = intensitas5;
                    }
                    //Debug.WriteLine("matrikImage[" + y + "," + x + "] : " + matrikImage[y, x]);
                }
            }
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0;
            int jumlah;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width - 1; x++)
                {
                    h = bmp6.GetPixel(x, y);
                    if (matrikImage[y, x] != 0 && matrikImage[y, x + 1] != 0)
                        if (h.R == 255)
                        {
                            c1 = matrikImage[y, x];
                            c2 = matrikImage[y, x + 1];
                            jumlah = 0;
                            if (matrikCooccurrence[c1, c2] == 0)
                            {
                                for (int z = 0; z < height; z++)
                                {
                                    for (int z1 = 0; z1 < width - 2; z1++)
                                    {
                                        c3 = matrikImage[z, z1 + 1];
                                        c4 = matrikImage[z, z1 + 2];
                                        if (c3 == c1 && c4 == c2)
                                        {
                                            jumlah = jumlah + 1;
                                            matrikCooccurrence[c1, c2] = jumlah;
                                        }
                                    }
                                }
                            }
                        }
                }
            }
            #endregion
            /*for (int y = 0; y < 16; y++)
            {
            for (int x = 0; x < 16; x++)
            {
            Debug.WriteLine(y + "," + x + " : " + matrikCooccurrence[y, x]);
            }
            }*/
            double jumlahIntensitasDalamOccurrence = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    jumlahIntensitasDalamOccurrence = jumlahIntensitasDalamOccurrence + matrikCooccurrence[y, x];
                }
            }
            Debug.WriteLine("jumlahIntensitasDalamOccurrence : " + jumlahIntensitasDalamOccurrence);
            //Mean Matrik Cooccurence Untuk ngitung fitur variance
            double MeanMatrikCo = 0;
            MeanMatrikCo = jumlahIntensitasDalamOccurrence / (16 * 16);
            Debug.WriteLine("Mean Matrik Co Occurence : " + MeanMatrikCo);
            double jumlahnormalisasi = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    //Debug.WriteLine(y + "," + x + " : " + matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence);
                    jumlahnormalisasi = jumlahnormalisasi + (matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence);
                }
            }
            //jumlah normalisasi pasti 1
            Debug.WriteLine("jumlahnormalisasi :" + jumlahnormalisasi);
            //ENERGI /ASM (ANGULAR SECOND MOMENT)
            double energi1 = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    energi1 = energi1 + Math.Pow((matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence), 2);
                }
            }
            Debug.WriteLine("energi 1 : " + energi1);
            //ENTROPI
            double entropi1 = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (matrikCooccurrence[y, x] != 0)
                    {
                        entropi1 = (entropi1 + (matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence) *
                        Math.Log(matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence));
                    }
                }
            }
            Debug.WriteLine("entropi 1 : " + -entropi1);
            //INVERS DIFFERENCE MOMENT (IDM)
            double IDM = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (matrikCooccurrence[y, x] != 0)
                    {
                        IDM = (IDM + (1 / (1 + Math.Pow(x, 2))) * (matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence));
                    }
                }
            }
            Debug.WriteLine("IDM : " + IDM);
            //SUM OF SQUARES, VARIANCE
            double variance = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (matrikCooccurrence[y, x] != 0)
                    {
                        variance = (variance + Math.Pow((x - MeanMatrikCo), 2) * (matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence));
                    }
                }
            }
            Debug.WriteLine("variance : " + variance);
            //DISSIMILARITY
            double Dissimilarity = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (matrikCooccurrence[y, x] != 0)
                    {
                        Dissimilarity = (Dissimilarity + Math.Abs(x - y) * (matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence));
                    }
                }
            }
            Debug.WriteLine("Dissimilarity : " + Dissimilarity);
            //KONTRAS
            double kontras = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (matrikCooccurrence[y, x] != 0)
                    {
                        kontras = kontras + Math.Pow((y - x), 2) * (matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence);
                    }
                }
            }
            Debug.WriteLine("kontras : " + kontras);
            //HOMOGENITAS
            double homogenitas = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (matrikCooccurrence[y, x] != 0)
                    {
                        homogenitas = homogenitas + (matrikCooccurrence[y, x] / jumlahIntensitasDalamOccurrence) / (1 + Math.Abs(y - x));
                    }
                }
            }
            Debug.WriteLine("homogenitas : " + homogenitas);
        }
    }
}
