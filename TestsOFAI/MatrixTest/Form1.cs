using AI;
using AI.ComputerVision;
using AI.Statistics;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly int n = 15;
        private Matrix matrix = new Matrix();
        private Matrix matrixInv = new Matrix();

        private void button1_Click(object sender, EventArgs e)
        {
            Matrix mat = Statistic.randNorm(n, n);
            matrix = mat.Copy();

            heatMapControl1.CalculateHeatMap(matrix);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            matrixInv = matrix.Invers();
            heatMapControl1.CalculateHeatMap(matrixInv);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            heatMapControl1.CalculateHeatMap(matrix * matrixInv);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = "1.jpg";

            Bitmap bitmap = ImgConverter.GetBitmap(path);
            matrix = ImgConverter.BmpToMatr(bitmap);
            heatMapControl1.CalculateHeatMap(matrix);
        }
    }
}
