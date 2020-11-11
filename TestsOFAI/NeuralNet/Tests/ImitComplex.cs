using AI;
using AI.DSPCore;
using AI.ML.Datasets;
using AI.ML.NeuralNetwork.CoreNNW;
using AI.ML.NeuralNetwork.CoreNNW.Activations;
using AI.ML.NeuralNetwork.CoreNNW.Layers;
using AI.ML.NeuralNetwork.CoreNNW.Layers.ComplexLayers;
using AI.ML.NeuralNetwork.CoreNNW.Loss;
using AI.ML.NeuralNetwork.CoreNNW.Optimizers;
using AI.Statistics;
using System;
using System.Windows.Forms;

namespace NeuralNet.Tests
{
    public partial class ImitComplex : Form
    {
        public ImitComplex()
        {
            InitializeComponent();
            t = new Vector(n);

            double dt = 1.0 / n;

            for (int i = 1; i < n; i++)
            {
                t[i] = t[i - 1] + dt;
            }

            NNW.AddNewLayer(new Shape(n), new FeedForwardLayer(20));
            NNW.AddNewLayer(new ReShape(new Shape(10, 1, 2))); // Разделение на реальную и мнимую часть
            NNW.AddNewLayer(new FeedComplexLayer(10));// Комплексный слой
            NNW.AddNewLayer(new Flatten()); // Соединение реальной и мнимой части
            NNW.AddNewLayer(new FeedForwardLayer(outp));
            Console.WriteLine(NNW);
        }

        private readonly Vector t;
        private const int n = 1000, outp = 2;
        private const int l = 400;
        private readonly Random random = new Random(10);
        private readonly NNW NNW = new NNW(20);
        private readonly Vector ideal1 = new Vector(outp);
        private readonly Vector ideal2 = new Vector(outp);
        private readonly Vector[] x = new Vector[l], y = new Vector[l];

        // Генерация тестового сигнала
        private void button1_Click(object sender, EventArgs e)
        {
            ShDat();
        }

        // Обучение нейронной сети
        private void button2_Click(object sender, EventArgs e)
        {
            GetData();
            DataSetNoReccurent DatasetNo = new DataSetNoReccurent(x, y, new LossMSE(), 0.1);
            Trainer trainer = new Trainer(new GraphCPU(), TrainType.Online, new SGD(0.6));
            trainer.Train(8, 0.0005, NNW, DatasetNo, 0.0006);
        }

        private void ShDat()
        {
            Vector dat = random.NextDouble() > 0.5 ? GetSig(2) : GetSig(4);
            GraphCPU graph = new GraphCPU(false);
            Vector nnwOut = NNW.Activate(new NNValue(dat), graph).ToVector();

            chartVisual1.PlotBlack(t, dat);
            chartVisual2.BarBlack(nnwOut);
        }

        private Vector GetSig(int f)
        {
            Vector s = Signal.Rect(t, 1, f, 2.5 * random.NextDouble());
            s = (s - 0.5) * 2 + Statistic.randNorm(n);
            return s;
        }

        private void GetData()
        {
            for (int i = 0; i < l; i += 2)
            {
                x[i] = GetSig(2);
                x[i + 1] = GetSig(4);
                ideal1[0] = 1;
                ideal2[1] = 1;
                y[i] = ideal1;
                y[i + 1] = ideal2;
            }
        }

    }
}
