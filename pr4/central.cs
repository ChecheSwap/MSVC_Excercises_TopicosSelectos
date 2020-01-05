using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA4
{
    public partial class central : Form
    {
        public control  c1;
        public logica   l1;

        private List<string> lstPermitidos;        

        public int vMin = 0;
        public int vMax = 0;
        public int vX = 0;
        public int linea=0;
        public bool controlx = false;
        public central()
        {
            this.initialize();
        }
        public central(int n)
        {
            this.initialize();
            this.linea = n;
            this.Text = "Parametros Linea #" + n.ToString();
        }

        private void initialize()
        {            
            InitializeComponent();


            this.txt_maximo.KeyUp += (sender, e) => {
                this.onlyNumbers(e.KeyData.ToString(), ref this.txt_maximo);
            };
            this.txt_minimo.KeyUp += (sender, e) => {
                this.onlyNumbers(e.KeyData.ToString(), ref txt_minimo);
            };
            this.StartPosition = FormStartPosition.CenterScreen;

            this.lstPermitidos = new List<string>() {"SUBSTRACT","OEMMINUS","BACK",
                                                        "D0" , "D1","D2","D3","D4","D5",
                                                            "D6","D7","D8","D9","NUMPAD0","NUMPAD1",
                                                                "NUMPAD2","NUMPAD3","NUMPAD4","NUMPAD5","NUMPAD6","NUMPAD7",
                                                                    "NUMPAD8","NUMPAD9"};            
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;            
        }
        private void central_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txt_minimo;
            this.txt_minimo.Focus();                   
        }

        private void start()
        {
            if(this.txt_minimo.Text.Trim() != String.Empty && this.txt_maximo.Text.Trim() != String.Empty)
            {
                try
                {
                    this.vMin = int.Parse(this.txt_minimo.Text);
                    this.vMax = int.Parse(this.txt_maximo.Text);

                    if (this.vMin > this.vMax)
                    {
                        msg.danger("Valor menor debe ser menor a mayor y viceversa.");
                        this.txt_minimo.Focus();
                        return;
                    }

                    if (this.txtopd.Text != string.Empty)
                    {
                        this.vX = int.Parse(this.txtopd.Text);

                        if(!(this.vX > this.vMin && this.vX < this.vMax))
                        {
                            msg.danger("El valor especifico debe de estar entre margenes...");
                            this.txtopd.Focus();
                            this.controlx = true;
                            return;
                        }
                    }
                }
                catch(System.FormatException sfe)
                {
                    msg.danger("Formato incorrecto!");
                    this.txt_minimo.Focus();
                    return;                    
                }

                
            }
            else
            {
                msg.danger("Complete valores...");
                this.txt_minimo.Focus();
                return;
            }
                   
            this.c1 = new control(this);
            this.Hide();
            this.c1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.start();
        }

        private void onlyNumbers(string val, ref TextBox txtbase)
        {
        }

    }
}
