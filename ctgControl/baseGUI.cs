using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ctgControl
{
    public partial class baseGUI : Form
    {
        control c;
        public baseGUI()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.c = new control(this);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.c.ShowDialog();            
        }
    }
}
