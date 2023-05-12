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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
