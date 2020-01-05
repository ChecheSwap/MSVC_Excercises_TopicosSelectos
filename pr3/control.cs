using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA3
{
    public partial class control : Form
    {
        private Thread th_1;
        private central wParametros;
        private logica logic;

        public control(central wParametros)
        {
            InitializeComponent();            
            this.wParametros = wParametros;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.panel1.BackColor = Color.Blue;
            this.Closed += (sender, e) => { this.wParametros.Show(); };
            this.ShowIcon = false;
            this.logic = new logica(wParametros.vMin, wParametros.vMax, this);            
            
        }

        private void central_Load(object sender, EventArgs e)
        {
            this.lblranges.Text = "*Minimo = " + wParametros.vMin.ToString() + " *Maximo = " + wParametros.vMax.ToString();
        }

        private void genera()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Blue;
            this.btnstop.Enabled = true;
            this.btnstart.Enabled = false;
            this.logic.start();
        }

        public void check()
        {
            if (globals.state)
            {
                this.panel1.BackColor = Color.Red;
                if (this.btnstart.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        this.btnstart.Enabled = true;
                        this.btnstop.Enabled = false;
                    }));
                }
                else
                {
                    this.btnstart.Enabled = true;
                    this.btnstop.Enabled = false;
                }                
                msg.err("Umbral violado");                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {}

        private void button2_Click(object sender, EventArgs e)
        {
            this.btnstop.Enabled = false;
            this.btnstart.Enabled = true;
            this.logic.stop();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (msg.exit())
            {
                Environment.Exit(1);
            }
        }
    }
}
