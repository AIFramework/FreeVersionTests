﻿using AI;
using AI.DSPCore;
using AI.ML.NeuralNetwork;
using AI.ML.NeuralNetwork.CoreNNW;
using AI.ML.NeuralNetwork.CoreNNW.Activations;
using AI.ML.NeuralNetwork.CoreNNW.Layers;
using AI.ML.NeuralNetwork.CoreNNW.Layers.ConvDeconv;
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
    public partial class SignalAutoencoder : Form
    {
        public SignalAutoencoder()
        {
            InitializeComponent();
            x = new Vector[dataSempleCount];
            y = new Vector[dataSempleCount];
            
            t = new Vector(n);
            
            double dt = 1.0 / n;
           
            for (int i = 1; i < n; i++)
            {
                t[i] = t[i - 1] + dt; 
            }
        }

        NeuralNetworkMeneger networkMeneger;
        NNW nnw = new NNW();
        int n = 128, h = 25, dataSempleCount = 3000;
        bool lin = true; // тип автокодировщика


        Vector[] x, y;
        Vector t;

        // Линейный энкодер
        private void creatLin_Click(object sender, EventArgs e)
        {
            lin = true;

            nnw = new NNW();
            nnw.AddNewLayer(new Shape(n), new FeedForwardLayer(h));
            nnw.AddNewLayer(new FeedForwardLayer(n));

            CreateMeneger();
        }

        //Сверточный энкодер
        private void creatConv_Click(object sender, EventArgs e)
        {
            lin = false;


            nnw = new NNW();
            nnw.AddNewLayer(new Shape(n), new ConvolutionLayer(new ReLU(0.1), count: 2, h: 3, w: 1));
            nnw.AddNewLayer(new MaxPool1D());
            nnw.AddNewLayer(new ConvolutionLayer(new ReLU(0.1), count: 4, h: 3, w: 1));
            nnw.AddNewLayer(new MaxPool1D());
            nnw.AddNewLayer(new ConvolutionLayer(new ReLU(0.1), count: 8, h: 3, w: 1));
            nnw.AddNewLayer(new MaxPool1D());
            nnw.AddNewLayer(new Flatten());

            nnw.AddNewLayer(new FeedForwardLayer(h));
            nnw.AddNewLayer(new FeedForwardLayer(32, new ReLU(0.1)));

            nnw.AddNewLayer(new Upsampling2dBicibic(2, 1));
            nnw.AddNewLayer(new ConvolutionLayer(new ReLU(0.1), count: 3, h: 3, w: 1) { IsSame = true });
            nnw.AddNewLayer(new Upsampling2dBicibic(2, 1));
            nnw.AddNewLayer(new ConvolutionLayer(count: 1, h: 3, w: 1) { IsSame = true });
            
            
            CreateMeneger();
        }

        private void CreateMeneger()
        {
            networkMeneger = new NeuralNetworkMeneger(nnw);
            Console.WriteLine(nnw);
            ShowData();
        }

        private void test_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void train_Click(object sender, EventArgs e)
        {
            try
            {
                GenDataset();
                networkMeneger.Epoch = 20;
                networkMeneger.TrainNet(x, y);
                ShowData();
            }
            catch(Exception exept) 
            {
                Console.WriteLine(exept.Message);
            }
        }

        

        void GenDataset() 
        {
            Random random = new Random();

            for (int i = 0; i < dataSempleCount; i++)
            {
                var xy = GetSigXY(random);
                x[i] = xy.Item1;
                y[i] = xy.Item2;
            }
        }



        void ShowData() 
        {
            try
            {
               if(lin) Lin();
               else Conv();
            }
            catch (Exception exept)
            {
                Console.WriteLine(exept.Message);
            }
        }

        private void Lin()
        {
            Random random = new Random();
            var dat = GetSigXY(random).Item1;
            Vector nnwOut = networkMeneger.Forward(dat);


            GraphCPU graph = new GraphCPU(false);
            Vector hl = nnw.Layers[0].Activate(new NNValue(dat), graph).ToVector();

            sigChart.PlotBlack(t, dat);
            hChart.BarBlack(hl);
            outChart.PlotBlack(t, nnwOut);
        }

        private void Conv()
        {
            Random random = new Random();
            var dat = GetSigXY(random).Item1;
            Vector nnwOut = networkMeneger.Forward(dat);


            GraphCPU graph = new GraphCPU(false);

            // Нейросеть для формирования эмбедингов
            NNW net = new NNW();
            net.Layers.Add(nnw.Layers[0]);
            net.Layers.Add(nnw.Layers[1]);
            net.Layers.Add(nnw.Layers[2]);
            net.Layers.Add(nnw.Layers[3]);
            net.Layers.Add(nnw.Layers[4]);
            net.Layers.Add(nnw.Layers[5]);
            net.Layers.Add(nnw.Layers[6]);
            net.Layers.Add(nnw.Layers[7]);

            Vector hl = net.Activate(new NNValue(dat), graph).ToVector();

            sigChart.PlotBlack(t, dat);
            hChart.BarBlack(hl);
            outChart.PlotBlack(t, nnwOut);
        }

        Tuple<Vector, Vector> GetSigXYRect(Random random)
        {
            var s = Signal.Rect(t, 1, 2 + 6 * random.NextDouble(), 6 * random.NextDouble());
            s = (s - 0.5) * 2;
            return new Tuple<Vector, Vector>(s + 0.3 * Statistic.randNormP(t.Count, 10), s);
        }

        Tuple<Vector, Vector> GetSigXYSin(Random random)
        {
            var s = Signal.Sin(t, 1, 2 + 6 * random.NextDouble(), 6 * random.NextDouble());
            return new Tuple<Vector, Vector>(s + 0.3 * Statistic.randNormP(t.Count, 10), s);
        }

        Tuple<Vector, Vector> GetSigXY(Random random)
        {
            if (random.NextDouble() >= 0.5)
                return GetSigXYRect(random);
            else
                return GetSigXYSin(random);
        }
    }
}
