using AI;
using AI.ComputerVision;
using AI.ML.NeuralNetwork.Architectures;
using AI.ML.NeuralNetwork.CoreNNW;
using AI.ML.NeuralNetwork.CoreNNW.Activations;
using AI.ML.NeuralNetwork.CoreNNW.Layers;
using AI.ML.NeuralNetwork.CoreNNW.Optimizers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNet.Tests
{
    public partial class GanDemo : Form
    {
        public GanDemo()
        {
            InitializeComponent();

            generator.AddNewLayer(new Shape(5), new Flatten());
            generator.AddNewLayer(new FeedForwardLayer(10* 10* 2, new ReLU(0.2)));
            generator.AddNewLayer(new ReShape(new Shape(10, 10, 2)));
            generator.AddNewLayer(new ConvolutionLayer(new ReLU(0.2), 7, 3, 3) { IsSame = true });
            generator.AddNewLayer(new Upsampling2dBicibic());
            generator.AddNewLayer(new ConvolutionLayer(new ReLU(0.2), 6, 4, 4) { IsSame = true });
            generator.AddNewLayer(new Upsampling2dBicibic());
            generator.AddNewLayer(new ConvolutionLayer(new ReLU(0.2), 4, 3, 3) { IsSame = true });
            generator.AddNewLayer(new ConvolutionLayer(new TanhUnit(), 1, 3, 3) { IsSame = true });


            discriminator.AddNewLayer(generator.OutputShape, new ConvolutionLayer(new ReLU(0.2), 4, 3, 3));
            discriminator.AddNewLayer(new MaxPooling());
            discriminator.AddNewLayer(new ConvolutionLayer(new ReLU(0.2), 8, 3, 3));
            discriminator.AddNewLayer(new MaxPooling());
            discriminator.AddNewLayer(new Flatten());
            discriminator.AddNewLayer(new FeedForwardLayer(32, new ReLU(0.2)));
            discriminator.AddNewLayer(new FeedForwardLayer(1, new SigmoidWithBCE()));

            gan = new GanNet(generator, discriminator);

            matrices = new Matrix[1];
            Bitmap bitmap = new Bitmap("ganData\\1.jpg");
            bitmap = new Bitmap(bitmap, generator.OutputShape.W, generator.OutputShape.H);
            matrices[0] = ImgConverter.BmpToMatr(bitmap);

        }

        NNW discriminator = new NNW();
        NNW generator = new NNW();
        GanNet gan;
        Matrix[] matrices;

        private void button1_Click(object sender, EventArgs e)
        {
            Matrix m = gan.MatrixGenerate();
            img.Image = ImgConverter.ToBitmap(m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gan.Train(matrices, new Adam(),epoch:1000);
        }
    }
}
