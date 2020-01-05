using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ctgControl
{
    public partial class control : Form
    {
        private baseGUI baseg;
        public control(baseGUI gt)
        {
            this.baseg = gt;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.FormClosed += (sender, e) => { this.baseg.Close(); };
            this.MaximizeBox = false;

            this.Resize += (s, b) =>
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    this.baseg.WindowState = FormWindowState.Minimized;
                }
                else if (WindowState == FormWindowState.Normal)
                {
                    this.baseg.WindowState = FormWindowState.Maximized;
                }
            };

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void control_Load(object sender, EventArgs e)
        {
            this.Text = "Panel de Inicio";
            this.ShowInTaskbar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            Process.Start("TAREA1.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("TAREA2.exe");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Process.Start("TAREA3.exe");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Process.Start("TAREA4.exe");
        }
    }
}
