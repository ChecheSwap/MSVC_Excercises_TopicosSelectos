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
using TAREA4.CONTROLS;
using Excel = Microsoft.Office.Interop.Excel;
namespace TAREA4
{
    public partial class control : Form
    {
        private Thread th_1;
        private central wParametros;
        private logica logic;
        private tabModel dgvControl;
        public globals globals;
        public control(central wParametros)
        {
            InitializeComponent();

            this.globals = new globals();

            this.wParametros = wParametros;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.panel1.BackColor = Color.Blue;
            this.Closed += (sender, e) => { this.wParametros.Show(); };
            this.ShowIcon = false;

            if (wParametros.controlx)
            {
                this.logic = new logica(wParametros.vMin, wParametros.vMax, wParametros.vX,this);
            }
            else
            {
                this.logic = new logica(wParametros.vMin, wParametros.vMax, this);
            }
            this.label1.Text += wParametros.linea.ToString();                          
        }

        private void central_Load(object sender, EventArgs e)
        {
            this.lblranges.Text = "*Minimo = " + wParametros.vMin.ToString() + " *Maximo = " + wParametros.vMax.ToString();
            this.dgvControl = new tabModel(ref this.dgv);            
        }


        private void button1_Click(object sender, EventArgs e)
        {            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Blue;
            this.dgvControl.reset();
            this.btnstop.Enabled = true;
            this.btnstart.Enabled = false;
            this.logic.start();
        }

        public void updateGrid(string val)
        {
            this.dgvControl.add(val, ref this.dgv);
            
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.exporToExcel();
        }

        private void exporToExcel()
        {            
            this.dgv.SelectAll();
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
            }
            Excel.Application xlexcel;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}
