using AI;
using AI.ComputerVision;
using AI.HightLevelFunctions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TensorTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Tensor tensor = new Tensor(2, 2, 3);

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = ImgConverter.GetBitmap("1.jpg");
            bitmap = ImgConverter.BmpResizeM(bitmap, 400);
            pictureBox1.Image = bitmap;
            tensor = ImgConverter.BmpToTensor(bitmap);// Конвертирование изображение -> тензор
            pictureBox2.Image = ImgConverter.ToBitmap(tensor); // Конвертирование тензор -> изображение
            Decomposition();
        }

        // Уменьшить контраст /2
        private void button2_Click(object sender, EventArgs e)
        {
            tensor /= 2;
            pictureBox2.Image = ImgConverter.ToBitmap(tensor); // Конвертирование тензор -> изображение 
            Decomposition();
        }

        // Увеличить контраст x2
        private void button4_Click(object sender, EventArgs e)
        {
            tensor *= 2;
            pictureBox2.Image = ImgConverter.ToBitmap(tensor); // Конвертирование тензор -> изображение 
            Decomposition();
        }

        //Сигмоида
        private void button3_Click(object sender, EventArgs e)
        {
            tensor = ActivationFunctions.Sigmoid(tensor - tensor.Mean(), 9);// Гамма-фильтрация
            pictureBox2.Image = ImgConverter.ToBitmap(tensor);
            Decomposition();
        }


        private void Decomposition()
        {
            Matrix[] chanels = tensor.TensorToMatrixs();

            heatMapControl1.CalculateHeatMap(chanels[0]);
            heatMapControl2.CalculateHeatMap(chanels[1]);
            heatMapControl3.CalculateHeatMap(chanels[2]);
        }


    }
}
