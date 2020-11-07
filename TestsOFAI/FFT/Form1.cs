using AI;
using AI.DSPCore;
using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace FFT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            t = Vector.Time0(512, 1);
            signal = Signal.Sin(t, 4);
            signal2 = Signal.Rect(t, 4);
        }

        private readonly Vector signal, signal2;
        private readonly Vector t;

        private void button2_Click(object sender, EventArgs e)
        {
            Vector fft = FFT.CalcFFT(signal2).MagnitudeToVector();
            fft /= fft.Count;

            chartVisual1.Clear();
            chartVisual1.AddPlot(Vector.Seq0(1, t.Count), fft, "", Color.Red, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vector dft = DFT(signal2).MagnitudeToVector();

            chartVisual1.Clear();
            chartVisual1.AddPlot(Vector.Seq0(1, t.Count), dft, "", Color.Blue, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartVisual1.Clear();
            chartVisual1.AddPlot(t, signal2, "", Color.Blue, 1);
            chartVisual1.AddPlot(t, signal, "", Color.Green, 2);
        }


        // Дискретное преобразование Фурье
        public ComplexVector DFT(Vector vector)
        {
            ComplexVector complex = new ComplexVector(vector.Count);

            for (int i = 0; i < vector.Count; i++)
            {
                for (int j = 0; j < complex.Count; j++)
                {
                    complex[i] += vector[j] * Complex.Exp(-Complex.ImaginaryOne * 2.0 * Math.PI * i * j / complex.Count);
                }
            }

            return complex / complex.Count;
        }
    }
}
