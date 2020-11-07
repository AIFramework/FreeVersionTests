namespace NeuralNet.Tests
{
    partial class ImitComplex
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
            this.chartVisual1 = new AI.Charts.Control.ChartVisual();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chartVisual2 = new AI.Charts.Control.ChartVisual();
            this.SuspendLayout();
            // 
            // chartVisual1
            // 
            this.chartVisual1.AutoScroll = true;
            this.chartVisual1.BackColor = System.Drawing.Color.White;
            this.chartVisual1.ChartName = "График";
            this.chartVisual1.ForeColor = System.Drawing.Color.Black;
            this.chartVisual1.IsContextMenu = true;
            this.chartVisual1.IsLogScale = false;
            this.chartVisual1.IsMoove = true;
            this.chartVisual1.IsScale = true;
            this.chartVisual1.IsShowXY = true;
            this.chartVisual1.LabelX = "Ось Х";
            this.chartVisual1.LabelY = "Ось Y";
            this.chartVisual1.Location = new System.Drawing.Point(0, 0);
            this.chartVisual1.Name = "chartVisual1";
            this.chartVisual1.Size = new System.Drawing.Size(800, 303);
            this.chartVisual1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 629);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(81, 629);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Train";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chartVisual2
            // 
            this.chartVisual2.AutoScroll = true;
            this.chartVisual2.BackColor = System.Drawing.Color.White;
            this.chartVisual2.ChartName = "График";
            this.chartVisual2.ForeColor = System.Drawing.Color.Black;
            this.chartVisual2.IsContextMenu = true;
            this.chartVisual2.IsLogScale = false;
            this.chartVisual2.IsMoove = true;
            this.chartVisual2.IsScale = true;
            this.chartVisual2.IsShowXY = true;
            this.chartVisual2.LabelX = "Ось Х";
            this.chartVisual2.LabelY = "Ось Y";
            this.chartVisual2.Location = new System.Drawing.Point(0, 309);
            this.chartVisual2.Name = "chartVisual2";
            this.chartVisual2.Size = new System.Drawing.Size(800, 314);
            this.chartVisual2.TabIndex = 0;
            // 
            // ImitComplex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 656);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chartVisual2);
            this.Controls.Add(this.chartVisual1);
            this.Name = "ImitComplex";
            this.Text = "ImitComplex";
            this.ResumeLayout(false);

        }

        #endregion

        private AI.Charts.Control.ChartVisual chartVisual1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private AI.Charts.Control.ChartVisual chartVisual2;
    }
}