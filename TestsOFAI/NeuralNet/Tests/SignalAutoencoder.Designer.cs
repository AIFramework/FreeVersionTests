namespace NeuralNet.Tests
{
    partial class SignalAutoencoder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sigChart = new AI.Charts.Control.ChartVisual();
            this.hChart = new AI.Charts.Control.ChartVisual();
            this.outChart = new AI.Charts.Control.ChartVisual();
            this.creatLin = new System.Windows.Forms.Button();
            this.creatConv = new System.Windows.Forms.Button();
            this.train = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sigChart
            // 
            this.sigChart.AutoScroll = true;
            this.sigChart.BackColor = System.Drawing.Color.White;
            this.sigChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigChart.ChartName = "Сигнал";
            this.sigChart.ForeColor = System.Drawing.Color.Black;
            this.sigChart.IsContextMenu = true;
            this.sigChart.IsLogScale = false;
            this.sigChart.IsMoove = true;
            this.sigChart.IsScale = true;
            this.sigChart.IsShowXY = true;
            this.sigChart.LabelX = "Ось Х";
            this.sigChart.LabelY = "Ось Y";
            this.sigChart.Location = new System.Drawing.Point(13, 13);
            this.sigChart.Name = "sigChart";
            this.sigChart.Size = new System.Drawing.Size(687, 162);
            this.sigChart.TabIndex = 0;
            // 
            // hChart
            // 
            this.hChart.AutoScroll = true;
            this.hChart.BackColor = System.Drawing.Color.White;
            this.hChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hChart.ChartName = "Скрытое состояние";
            this.hChart.ForeColor = System.Drawing.Color.Black;
            this.hChart.IsContextMenu = true;
            this.hChart.IsLogScale = false;
            this.hChart.IsMoove = true;
            this.hChart.IsScale = true;
            this.hChart.IsShowXY = true;
            this.hChart.LabelX = "Ось Х";
            this.hChart.LabelY = "Ось Y";
            this.hChart.Location = new System.Drawing.Point(13, 181);
            this.hChart.Name = "hChart";
            this.hChart.Size = new System.Drawing.Size(687, 170);
            this.hChart.TabIndex = 0;
            // 
            // outChart
            // 
            this.outChart.AutoScroll = true;
            this.outChart.BackColor = System.Drawing.Color.White;
            this.outChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outChart.ChartName = "Выход сети";
            this.outChart.ForeColor = System.Drawing.Color.Black;
            this.outChart.IsContextMenu = true;
            this.outChart.IsLogScale = false;
            this.outChart.IsMoove = true;
            this.outChart.IsScale = true;
            this.outChart.IsShowXY = true;
            this.outChart.LabelX = "Ось Х";
            this.outChart.LabelY = "Ось Y";
            this.outChart.Location = new System.Drawing.Point(13, 357);
            this.outChart.Name = "outChart";
            this.outChart.Size = new System.Drawing.Size(687, 185);
            this.outChart.TabIndex = 0;
            // 
            // creatLin
            // 
            this.creatLin.Location = new System.Drawing.Point(13, 549);
            this.creatLin.Name = "creatLin";
            this.creatLin.Size = new System.Drawing.Size(137, 23);
            this.creatLin.TabIndex = 1;
            this.creatLin.Text = "Создать линейный";
            this.creatLin.UseVisualStyleBackColor = true;
            this.creatLin.Click += new System.EventHandler(this.creatLin_Click);
            // 
            // creatConv
            // 
            this.creatConv.Location = new System.Drawing.Point(13, 578);
            this.creatConv.Name = "creatConv";
            this.creatConv.Size = new System.Drawing.Size(137, 23);
            this.creatConv.TabIndex = 1;
            this.creatConv.Text = "Создать сверточный";
            this.creatConv.UseVisualStyleBackColor = true;
            this.creatConv.Click += new System.EventHandler(this.creatConv_Click);
            // 
            // train
            // 
            this.train.Location = new System.Drawing.Point(183, 548);
            this.train.Name = "train";
            this.train.Size = new System.Drawing.Size(75, 23);
            this.train.TabIndex = 2;
            this.train.Text = "Учить";
            this.train.UseVisualStyleBackColor = true;
            this.train.Click += new System.EventHandler(this.train_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(183, 579);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 23);
            this.test.TabIndex = 2;
            this.test.Text = "Тест";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // SignalAutoencoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(704, 614);
            this.Controls.Add(this.test);
            this.Controls.Add(this.train);
            this.Controls.Add(this.creatConv);
            this.Controls.Add(this.creatLin);
            this.Controls.Add(this.outChart);
            this.Controls.Add(this.hChart);
            this.Controls.Add(this.sigChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SignalAutoencoder";
            this.Text = "SignalAutoencoder";
            this.ResumeLayout(false);

        }

        #endregion

        private AI.Charts.Control.ChartVisual sigChart;
        private AI.Charts.Control.ChartVisual hChart;
        private AI.Charts.Control.ChartVisual outChart;
        private System.Windows.Forms.Button creatLin;
        private System.Windows.Forms.Button creatConv;
        private System.Windows.Forms.Button train;
        private System.Windows.Forms.Button test;
    }
}