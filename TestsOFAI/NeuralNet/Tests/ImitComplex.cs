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
            NNW.AddNewLayer(new Shape(n), new ReShape(new Shape(n/2, 1,2)));
            NNW.AddNewLayer(new FeedComplexLayer(12, new ReLU(0.1)));
            NNW.AddNewLayer(new FeedForwardLayer(outp, new SigmoidUnit()));
        }

        Vector t;
        const int n = 130, outp = 3;
        const int l = 200;
        Random random = new Random(10);
        NNW NNW = new NNW(20);
        Vector ideal1 = new Vector(outp);
        Vector ideal2 = new Vector(outp);

        Vector[] x = new Vector[l], y = new Vector[l];

        private void button1_Click(object sender, EventArgs e)
        {
            ShDat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetData();
            DataSetNoReccurent complexDatasetNo = new DataSetNoReccurent(x, y, new LossMSE(),0.1);
            Trainer trainer = new Trainer(new GraphCPU(), TrainType.Online, new Adam());
            trainer.Train(8, 0.001, NNW, complexDatasetNo, 0.0006);
        }

        private void ShDat()
        {
            var dat = random.NextDouble() > 0.5 ? GetSig(2) : GetSig(4);
            GraphCPU graph = new GraphCPU(false);
            var nnwOut = NNW.Activate(new NNValue(dat), graph).ToVector();

            chartVisual1.PlotBlack(t, dat);
            chartVisual2.BarBlack(nnwOut);
        }



        Vector GetSig(int f)
        {
            var s = Signal.Rect(t, 1, f, 0.5 * random.NextDouble());
            s = (s - 0.5) * 2+Statistic.randNorm(n);
            return s;
        }

        void GetData()
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
