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

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            //mendapatkan dimensi image
            int height = bmp1.Height;
            int width = bmp1.Width;
            Bitmap bmp3 = new Bitmap(pictureBox4.Image);
            Double red = 0, orange = 0, yellow = 0, green = 0, cyan = 0, blue = 0,
            purple = 0, magenta = 0, pink = 0, gray = 0, black = 0, white = 0;
            Double derajatRed = 0, derajatOrange = 0, derajatYellow = 0, derajatGreen = 0,
            derajatCyan = 0, derajatBlue = 0, derajatPurple = 0, derajatGray = 0,
            derajatWhite = 0, derajatBlack = 0;
            Double derajatMagenta = 0, derajatPink = 0;
            int jumPixelBuah = 0;
            Double persentaseRed, persentaseOrange, persentaseYellow,
            persentaseGreen, persentaseCyan, persentaseBlue, persentasePurple,
            persentaseMagenta, persentasePink, persentaseGray, persentaseWhite,
            persentaseBlack;
            double jumlahSeluruhDerajat = 0;
            //kelas color
            Color p;
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);
            int height2 = bmp2.Height;
            int width2 = bmp2.Width;
            //menentukan panjang array untuk menyimpan nilai HSV
            int panjangArray = height2 * width2;
            //membuat array untuk menyimpan nilai Hue Saturation and Value
            Double[,] H = new Double[width2, height2];
            Double[,] S = new Double[width2, height2];
            Double[,] V = new Double[width2, height2];
            //konversi ke HSV
            Double r1, g1, b1, rgb;
            for (int y = 0; y < height2; y++)
            {
                for (int x = 0; x < width2; x++)
                {
                    p = bmp2.GetPixel(x, y);
                    rgb = p.R + p.G + p.B;
                    r1 = p.R / rgb;
                    g1 = p.G / rgb;
                    b1 = p.B / rgb;
                    //Value(V)
                    V[x, y] = Math.Max(Math.Max(r1, g1), b1);
                    //Saturation(S)
                    if (V[x, y] == 0)
                    {
                        S[x, y] = 0;
                    }
                    else
                    {
                        S[x, y] = 1 - Math.Min(Math.Min(r1, g1), b1) / V[x, y];
                    }
                    //Hue(H)
                    if (S[x, y] == 0)
                    {
                        H[x, y] = 0;
                    }
                    else if (V[x, y] == r1)
                    {
                        H[x, y] = 60 * (g1 - b1) / (S[x, y] * V[x, y]);
                    }
                    else if (V[x, y] == g1)
                    {
                        H[x, y] = 60 * (2 + (b1 - r1) / (S[x, y] * V[x, y]));
                    }
                    else if (V[x, y] == b1)
                    {
                        H[x, y] = 60 * (4 + (r1 - g1) / (S[x, y] * V[x, y]));
                    }
                    if (H[x, y] < 0)
                    {
                        H[x, y] = H[x, y] + 360;
                    }
                    if (H[x, y] > 255)
                    {
                        // Debug.WriteLine("H : "+H[x,y]);
                    }
                }
            }
            //Menghitung derajaat keanggotaan tiap warna
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp3.GetPixel(x, y);
                    if (p.R == 255 && p.G == 255 && p.B == 255)
                    {
                        //Red segitiga kanan
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatRed = 0;
                        }
                        else if (H[x, y] >= 0 && H[x, y] <= 21)
                        {
                            derajatRed = (21 - H[x, y]) / 21;
                        }
                        //Red segitiga kiri
                        else if (H[x, y] == 255)
                        {
                            derajatRed = 1;
                        }
                        else if (H[x, y] > 234 && H[x, y] <= 255)
                        {
                            derajatRed = (H[x, y] - 234) / (255 - 234);
                        }
                        red = red + derajatRed;
                        //Orange
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatOrange = 0;
                        }
                        else if (H[x, y] > 0 && H[x, y] <= 21)
                        {
                            derajatOrange = (H[x, y] - 0) / 21;
                        }
                        else if (H[x, y] > 21 && H[x, y] < 43)
                        {
                            derajatOrange = (43 - H[x, y]) / (43 - 21);
                        }
                        orange = orange + derajatOrange;
                        //Yellow
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatYellow = 0;
                        }
                        else if (H[x, y] > 21 && H[x, y] <= 43)
                        {
                            derajatYellow = (H[x, y] - 21) / (43 - 21);
                        }
                        else if (H[x, y] > 43 && H[x, y] <= 65)
                        {
                            derajatYellow = (65 - H[x, y]) / (65 - 43);
                        }
                        yellow = yellow + derajatYellow;
                        //Cyan
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatCyan = 0;
                        }
                        else if (H[x, y] > 105 && H[x, y] <= 128)
                        {
                            derajatCyan = (H[x, y] - 105) / (128 - 105);
                        }
                        else if (H[x, y] > 128 && H[x, y] <= 155)
                        {
                            derajatCyan = (155 - H[x, y]) / (155 - 128);
                        }
                        cyan = cyan;
                        //Green (Trapesium)
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatGreen = 0;
                        }
                        else if (H[x, y] > 43 && H[x, y] < 65)
                        {
                            derajatGreen = (H[x, y] - 43) / (65 - 43);
                        }
                        else if (H[x, y] >= 65 && H[x, y] <= 105)
                        {
                            derajatGreen = 1;
                        }
                        else if (H[x, y] > 105 && H[x, y] <= 128)
                        {
                            derajatGreen = (128 - H[x, y]) / (128 - 105);
                        }
                        green = green + derajatGreen + derajatCyan;
                        //Blue (Trapesium)
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatBlue = 0;
                        }
                        else if (H[x, y] > 128 && H[x, y] < 155)
                        {
                            derajatBlue = (H[x, y] - 128) / (155 - 128);
                        }
                        else if (H[x, y] >= 155 && H[x, y] <= 180)
                        {
                            derajatBlue = 1;
                        }
                        else if (H[x, y] > 180 && H[x, y] <= 191)
                        {
                            derajatBlue = (191 - H[x, y]) / (191 - 180);
                        }
                        blue = blue + derajatBlue;
                        //Purple
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatPurple = 0;
                        }
                        else if (H[x, y] >= 180 && H[x, y] <= 191)
                        {
                            derajatPurple = (H[x, y] - 180) / (191 - 180);
                        }
                        else if (H[x, y] > 191 && H[x, y] <= 213)
                        {
                            derajatPurple = (213 - H[x, y]) / (213 - 191);
                        }
                        purple = purple + derajatPurple;
                        //Magenta
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatMagenta = 0;
                        }
                        else if (H[x, y] > 191 && H[x, y] < 213)
                        {
                            derajatMagenta = (H[x, y] - 191) / (213 - 191);
                        }
                        else if (H[x, y] > 213 && H[x, y] < 234)
                        {
                            derajatMagenta = (234 - H[x, y]) / (234 - 213);
                        }
                        magenta = magenta + derajatMagenta;
                        //Pink
                        if (H[x, y] == 0 && S[x, y] == 0)
                        {
                            derajatPink = 0;
                        }
                        else if (H[x, y] >= 213 && H[x, y] <= 234)
                        {
                            derajatPink = (H[x, y] - 213) / (234 - 213);
                        }
                        else if (H[x, y] > 234 && H[x, y] <= 255)
                        {
                            derajatPink = (255 - H[x, y]) / (255 - 234);
                        }
                        pink = pink + derajatPink;
                        //Gray
                        if (S[x, y] > 0 && S[x, y] <= 0.2)
                        {
                            derajatGray = 1;
                        }
                        gray = gray + derajatGray;
                        //White
                        if (S[x, y] == 0)
                        {
                            derajatWhite = 1;
                        }
                        white = white + derajatWhite;
                        //Black
                        if (V[x, y] == 0)
                        {
                            derajatBlack = 1;
                        }
                        black = black + derajatBlack;
                        jumPixelBuah = jumPixelBuah + 1;
                    }
                }
            }
            jumlahSeluruhDerajat = (red + orange + yellow + green + cyan + blue + purple + magenta + pink + gray + white +
           black);
            persentaseRed = Math.Round(((red / jumlahSeluruhDerajat) * 100), 2);
            persentaseOrange = Math.Round(((orange / jumlahSeluruhDerajat) * 100), 2);
            persentaseYellow = Math.Round(((yellow / jumlahSeluruhDerajat) * 100), 2);
            persentaseGreen = Math.Round(((green / jumlahSeluruhDerajat) * 100), 2);
            persentaseCyan = Math.Round((cyan / jumlahSeluruhDerajat * 100), 2);
            persentaseBlue = Math.Round((blue / jumlahSeluruhDerajat * 100), 2);
            persentasePurple = Math.Round((purple / jumlahSeluruhDerajat * 100), 2);
            persentaseMagenta = Math.Round((magenta / jumlahSeluruhDerajat * 100), 2);
            persentasePink = Math.Round((pink / jumlahSeluruhDerajat * 100), 2);
            persentaseGray = Math.Round((gray / jumlahSeluruhDerajat * 100), 2);
            persentaseBlack = Math.Round((black / jumlahSeluruhDerajat * 100), 2);
            persentaseWhite = Math.Round((white / jumlahSeluruhDerajat * 100), 2);
            Debug.WriteLine("jumlah seluruh derajat : " + jumlahSeluruhDerajat);
            Debug.WriteLine("persentase Red :" + persentaseRed);
            Debug.WriteLine("persentase Orange :" + persentaseOrange);
            Debug.WriteLine("persentase Yellow :" + persentaseYellow);
            Debug.WriteLine("persentase Green :" + persentaseGreen);
            Debug.WriteLine("persentase Cyan :" + persentaseCyan);
            Debug.WriteLine("persentase Blue :" + persentaseBlue);
            Debug.WriteLine("persentase Purple :" + persentasePurple);
            Debug.WriteLine("persentase Magenta :" + persentaseMagenta);
            Debug.WriteLine("persentase Pink :" + persentasePink);
            Debug.WriteLine("persentase Gray :" + persentaseGray);
            Debug.WriteLine("persentase Black :" + persentaseBlack);
            Debug.WriteLine("persentase White :" + persentaseWhite);
            //Segmentasi
            Double[,] C = new Double[width2, height2];
            Double[,] X = new Double[width2, height2];
            Double[,] m = new Double[width2, height2];
            Double[,] H1 = new Double[width2, height2];
            Double R1 = 0, G1 = 0, B1 = 0;
            Bitmap bmp4 = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp3.GetPixel(x, y);
                    if (p.R == 255 && p.G == 255 && p.B == 255)
                    {
                        //Ubah komponen Hue
                        if (H[x, y] <= 11)
                        {
                            H[x, y] = 0;
                        }
                        else if (H[x, y] > 11 && H[x, y] <= 37)
                        {
                            H[x, y] = 21;
                        }
                        else if (H[x, y] > 37 && H[x, y] <= 54)
                        {
                            H[x, y] = 58;
                        }
                        else if (H[x, y] > 54 && H[x, y] <= 116)
                        {
                            H[x, y] = 95;
                        }
                        else if (H[x, y] > 116 && H[x, y] <= 141)
                        {
                            H[x, y] = 128;
                        }
                        else if (H[x, y] > 141 && H[x, y] <= 185)
                        {
                            H[x, y] = 170;
                        }
                        else if (H[x, y] > 185 && H[x, y] <= 202)
                        {
                            H[x, y] = 191;
                        }
                        else if (H[x, y] > 202 && H[x, y] <= 223)
                        {
                            H[x, y] = 213;
                        }
                        else if (H[x, y] > 223 && H[x, y] <= 244)
                        {
                            H[x, y] = 234;
                        }
                        else
                        {
                            H[x, y] = 0;
                        }
                        //Konversi HSV Ke RGB
                        if (S[x, y] == 0)
                        {
                            R1 = Convert.ToInt16(V[x, y]);
                            G1 = Convert.ToInt16(V[x, y]);
                            B1 = Convert.ToInt16(V[x, y]);
                        }
                        else
                        {
                            H[x, y] = H[x, y] / 60;
                            Double sektor;
                            sektor = Math.Floor(H[x, y]);
                            Double faktor = H[x, y] - sektor;
                            Double p1, q, t;
                            p1 = V[x, y] * (1 - S[x, y]);
                            q = V[x, y] * (1 - (S[x, y] * faktor));
                            t = V[x, y] * (1 - (S[x, y] * (1 - faktor)));
                            if (sektor == 0)
                            {
                                R1 = (V[x, y]) * 255;
                                G1 = t * 255;
                                B1 = p1 * 255;
                            }
                            else if (sektor == 1)
                            {
                                R1 = q * 255;
                                G1 = (V[x, y]) * 255;
                                B1 = p1 * 255;
                            }
                            else if (sektor == 2)
                            {
                                R1 = q * 255;
                                G1 = (V[x, y]) * 255;
                                B1 = p1 * 255;
                            }
                            bmp4.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(Math.Round(R1)),
                           Convert.ToInt32(Math.Round(G1)), Convert.ToInt32(Math.Round(B1))));
                        }
                        if (H1[x, y] > 0)
                        {
                            //Debug.WriteLine(" H : " + H1[x,y]);
                        }
                    }
                }
            }
            pictureBox3.Image = bmp4;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
