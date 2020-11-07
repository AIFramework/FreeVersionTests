using AI;
using AI.ComputerVision;
using AI.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n = 15;
        Matrix matrix = new Matrix();
        Matrix matrixInv = new Matrix();

        private void button1_Click(object sender, EventArgs e)
        {
            var mat = Statistic.randNorm(n, n);
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
            heatMapControl1.CalculateHeatMap(matrix*matrixInv);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var path = "1.jpg";

            Bitmap bitmap = ImgConverter.GetBitmap(path);
            matrix = ImgConverter.BmpToMatr(bitmap);
            heatMapControl1.CalculateHeatMap(matrix);
        }
    }
}
