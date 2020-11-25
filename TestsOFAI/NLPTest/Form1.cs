using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI;
using AI.NLP;

namespace NLPTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string str = File.ReadAllText("1.txt");
            tokinizer.Train(str);
        }

        TextTokenizer tokinizer = new TextTokenizer();

        private void button1_Click(object sender, EventArgs e)
        {
            chartVisual1.PlotBlack(tokinizer.GetSeq2Tokens(textBox1.Text).TransformVector(x => Math.Log(x+1.1)));
        }
    }
}
