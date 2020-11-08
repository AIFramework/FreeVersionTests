using NeuralNet.Tests;
using System.Windows.Forms;

namespace NeuralNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignalAutoencoder sig = new SignalAutoencoder();
            sig.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ComplexNet complexNet = new ComplexNet();
            complexNet.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImitComplex imitComplex = new ImitComplex();
            imitComplex.Show();
        }
    }
}
