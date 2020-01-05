using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA3
{
    public partial class central : Form
    {
        public control  c1;
        public logica   l1;
        private Boolean fkeypress;
        private Boolean keycontrol;
        private List<string> lstPermitidos;

        public int vMin = 0;
        public int vMax = 0;

        public central()
        {
            this.fkeypress = false;
            InitializeComponent();

            
            this.txt_maximo.KeyUp += (sender, e) => {
                this.onlyNumbers(e.KeyData.ToString(),ref this.txt_maximo);
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
            this.keycontrol = false;
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
                }
                catch(System.FormatException sfe)
                {
                    msg.danger("Formato incorrecto!");
                    this.txt_minimo.Focus();
                    return;                    
                }

                if(this.vMin > this.vMax)
                {
                    msg.danger("Valor menor debe ser menor a mayor y viceversa.");
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
        {/*
            this.keycontrol = true;

            bool Vlocal = false;
            if(txtbase.Text.Length == 0 || val.ToUpper() == "RETURN")
            {
                return;
            }
            
            if (!this.lstPermitidos.Contains(val.ToUpper()))
            {                
                Vlocal = true;
            }
            else
            {
                if(txtbase.Text.Contains("-") && val == "-")
                {                    
                    Vlocal = true;
                }
            }

            if (Vlocal)
            {
                txtbase.Text = txtbase.Text.Substring(0, txtbase.Text.Length - 1);
                txtbase.SelectionStart = txtbase.Text.Length;
                Vlocal = !Vlocal;
            }       */
        }

    }
}
