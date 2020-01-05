using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA4.APPRUN
{
    public partial class ctdAgrupador : Form
    {
        List<central> lstBase;

        public ctdAgrupador()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            
            this.lstBase = new List<central>() { };

            for (int x = 0; x < 2; ++x)
            {
                central tmp = new central(x + 1);
                tmp.Show();
                this.lstBase.Add(tmp);
                this.Shown += (sender, e) => { this.WindowState = FormWindowState.Minimized; };
            }
        }

        private void ctdAgrupador_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
