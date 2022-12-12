using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlotTest.PlotForms
{
    public partial class LCChartForm : Form
    {
        public CartesianChart MainPlot
        {
            get { return this.cartesianChart1; }
        }

        public LCChartForm()
        {
            InitializeComponent();
            MainPlot.EasingFunction = null; // disable animations
            MainPlot.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.Both; // allow zooming
        }
    }
}
