﻿using AI;
using AI.DSPCore;
using AI.ML.ComplexNet;
using AI.ML.ComplexNet.Activations;
using AI.ML.ComplexNet.Layers;
using AI.ML.ComplexNet.Loss;
using AI.ML.ComplexNet.Opts;
using AI.ML.Datasets;
using AI.ML.NeuralNetwork.CoreNNW;
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
    public partial class ComplexNet : Form
    {
        public ComplexNet()
        {
            InitializeComponent();
            t = new Vector(n);

            double dt = 1.0 / n;

            for (int i = 1; i < n; i++)
            {
                t[i] = t[i - 1] + dt;
            }
             NNW.AddNewLayer(new Shape(n), new ComplexFeedForwardLayer(outp, new CLinearUnit()));
        }

        Vector t;
        const int n = 200, outp = 12;
        const int l = 2000;
        Random random = new Random(10);
        CNNW NNW = new CNNW(20);
        Vector ideal1 = new Vector(outp);
        Vector ideal2 = new Vector(outp);

        Vector[] x = new Vector[l], y = new Vector[l];


        private void button1_Click(object sender, EventArgs e)
        {
            ShDat();
        }

        private void ShDat()
        {
            var dat = random.NextDouble()>0.5? GetSig(2): GetSig(4);
            CGraphCPU graph = new CGraphCPU(false);
            var nnwOut = NNW.Activate(new NNComplexValue(dat), graph).ToComplexVector();

            chartVisual1.PlotBlack(t, dat);
            chartVisual2.PlotComplex(nnwOut);
        }

     

        Vector GetSig(int f)
        {
            var s = Signal.Rect(t, 1, f, 0.5 * random.NextDouble());
            s = (s - 0.5) * 2;
            return s;
        }


        void GetData() 
        {
            for (int i = 0; i < l; i+=2)
            {
                x[i] = GetSig(2);
                x[i+1] = GetSig(4);
                ideal1[0] = 1;
                ideal2[1] = 1;
                y[i] = ideal1;
                y[i+1] = ideal2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetData();
            ComplexDatasetNoRecurrent complexDatasetNo = new ComplexDatasetNoRecurrent(x,y, new ComplexMSE());
            CTrainer trainer = new CTrainer(new CGraphCPU(), TrainType.Online, new CSGD(0.6));
            trainer.Train(8, 0.01, NNW, complexDatasetNo, 0);

        }
    }
}