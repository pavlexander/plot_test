namespace PlotTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPlotCandlesLC = new System.Windows.Forms.Button();
            this.btnPlotCandlesOxy = new System.Windows.Forms.Button();
            this.btnPlotCandlesScott = new System.Windows.Forms.Button();
            this.txtCandlesCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlotCandlesLC);
            this.groupBox1.Controls.Add(this.btnPlotCandlesOxy);
            this.groupBox1.Controls.Add(this.btnPlotCandlesScott);
            this.groupBox1.Controls.Add(this.txtCandlesCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Candles";
            // 
            // btnPlotCandlesLC
            // 
            this.btnPlotCandlesLC.Location = new System.Drawing.Point(6, 136);
            this.btnPlotCandlesLC.Name = "btnPlotCandlesLC";
            this.btnPlotCandlesLC.Size = new System.Drawing.Size(148, 23);
            this.btnPlotCandlesLC.TabIndex = 4;
            this.btnPlotCandlesLC.Text = "Plot with LiveCharts";
            this.btnPlotCandlesLC.UseVisualStyleBackColor = true;
            this.btnPlotCandlesLC.Click += new System.EventHandler(this.btnPlotCandlesLC_Click);
            // 
            // btnPlotCandlesOxy
            // 
            this.btnPlotCandlesOxy.Location = new System.Drawing.Point(6, 107);
            this.btnPlotCandlesOxy.Name = "btnPlotCandlesOxy";
            this.btnPlotCandlesOxy.Size = new System.Drawing.Size(148, 23);
            this.btnPlotCandlesOxy.TabIndex = 3;
            this.btnPlotCandlesOxy.Text = "Plot with OxyPlot";
            this.btnPlotCandlesOxy.UseVisualStyleBackColor = true;
            this.btnPlotCandlesOxy.Click += new System.EventHandler(this.btnPlotCandlesOxy_Click);
            // 
            // btnPlotCandlesScott
            // 
            this.btnPlotCandlesScott.Location = new System.Drawing.Point(6, 78);
            this.btnPlotCandlesScott.Name = "btnPlotCandlesScott";
            this.btnPlotCandlesScott.Size = new System.Drawing.Size(148, 23);
            this.btnPlotCandlesScott.TabIndex = 2;
            this.btnPlotCandlesScott.Text = "Plot with ScottPlot";
            this.btnPlotCandlesScott.UseVisualStyleBackColor = true;
            this.btnPlotCandlesScott.Click += new System.EventHandler(this.btnPlotCandlesScott_Click);
            // 
            // txtCandlesCount
            // 
            this.txtCandlesCount.Location = new System.Drawing.Point(6, 49);
            this.txtCandlesCount.Name = "txtCandlesCount";
            this.txtCandlesCount.Size = new System.Drawing.Size(148, 23);
            this.txtCandlesCount.TabIndex = 1;
            this.txtCandlesCount.Text = "50000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of candles to load";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 207);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing best plot libraries for dotnet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnPlotCandlesLC;
        private Button btnPlotCandlesOxy;
        private Button btnPlotCandlesScott;
        private TextBox txtCandlesCount;
        private Label label1;
    }
}