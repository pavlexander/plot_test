using OxyPlot.WindowsForms;
using ScottPlot;
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
    public partial class ScottChartForm : Form
    {
        public FormsPlot MainPlot
        {
            get { return this.formsPlot1; }
        }
        
        public ScottChartForm()
        {
            InitializeComponent();
        }
    }
}
