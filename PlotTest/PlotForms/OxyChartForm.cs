using OxyPlot.WindowsForms;
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
    public partial class OxyChartForm : Form
    {
        public PlotView MainPlot
        {
            get { return this.plotView1; }
        }

        public OxyChartForm()
        {
            InitializeComponent();
        }
    }
}
