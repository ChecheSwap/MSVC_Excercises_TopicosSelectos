using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadora
{
    public partial class Form1 : Form
    {
        private double vStotal = default(double);
        private double vtotal = default(double);
        private bool vFlag_key = default(bool);
        private char cBackspacekey = default(char);
        private char cDelKey = default(char);
        private string current_operand = default(string);
        private List<string> lst_opa;
        private bool isfirst = false;
        private bool opa = false;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.vFlag_key = false;
            KeyPress += (sender, e) => { this.key_listener(e.KeyChar); };
            KeyDown += (sender, e) => { this.key_listenerBefore(e.KeyValue); };
            this.txt1.Text = "0";

            this.cBackspacekey = Convert.ToChar(Keys.Back);
            this.cDelKey = Convert.ToChar(Keys.Delete);

            this.txt1.TextChanged += (sender, args) =>
            {
                if (this.txt1.Text.Length == 0)
                {
                    this.txt1.Text = "0";
                }
            };
            this.txt1.Focus();
            this.ActiveControl = this.btnequal;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.vStotal = 0;
            this.vtotal = 0;
            this.current_operand = "F";
            this.lst_opa = new List<string>() { "SIN", "COS", "TAN" };
        }

        /// <summary>
        /// Funciones y procedimiento user defined
        /// </summary>
        /// 
        private void clear_vals()
        {
            this.vtotal = 0;
            this.vStotal = 0;
            this.txt2.Text = "0";
        }
        private void precalcula(string operation)
        {

            if (this.txt1.Text == "-")
            {
                this.txt1.Text = "-0";
            }

            if (this.vtotal != 0)
            {
                this.vStotal = Double.Parse(this.txt1.Text.Trim());
                this.isfirst = false;
            }
            else
            {
                this.vtotal = Double.Parse(this.txt1.Text.Trim());
                this.isfirst = true;
            }

            this.txt1.Text = "0";


            switch (operation)
            {
                case ("+"):
                    {
                        this.current_operand = "+";
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getsuma(ref this.vtotal, ref this.vStotal);
                        }
                        break;
                    }
                case ("-"):
                    {
                        this.current_operand = "-";
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getresta(ref this.vtotal, ref this.vStotal);
                        }
                        break;
                    }
                case ("/"):
                    {
                        this.current_operand = "/";
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getdivide(ref this.vtotal, ref this.vStotal);
                        }
                        break;
                    }
                case ("*"):
                    {
                        this.current_operand = "*";
                        if (!this.isfirst)
                        {                            
                            this.vtotal = central.getmultiplica(ref this.vtotal, ref this.vStotal);
                        }
                        break;
                    }

                case ("SIN"):
                    {
                        this.current_operand = "SIN";
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getseno(ref this.vStotal);
                        }
                        else
                        {
                            this.vtotal = central.getseno(ref this.vtotal);
                        }
                        break;
                    }
                case ("COS"):
                    {
                        this.current_operand = "COS";
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getcoseno(ref this.vStotal);
                        }
                        else
                        {
                            this.vtotal = central.getcoseno(ref this.vtotal);
                        }
                        break;
                    }
                case ("TAN"):
                    {
                        this.current_operand = "TAN";
                        if (!this.isfirst)
                        {
                            this.vtotal = central.gettangente(ref this.vStotal);
                        }
                        else
                        {
                            this.vtotal = central.gettangente(ref this.vtotal);
                        }
                        break;
                    }
                case ("X3"):
                    {                        
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getpow3(ref this.vStotal);
                        }
                        else
                        {
                            this.vtotal = central.getpow3(ref this.vtotal);
                        }
                        break;
                    }
                case ("X2"):
                    {
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getpow2(ref this.vStotal);
                        }
                        else
                        {
                            this.vtotal = central.getpow2(ref this.vtotal);
                        }
                        break;
                    }
                case ("sqrt"):
                    {
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getsqrt(ref this.vStotal);
                        }
                        else
                        {
                            this.vtotal = central.getsqrt(ref this.vtotal);
                        }
                        break;
                    }
                case ("INV"):
                    {                                          
                        if (!this.isfirst)
                        {
                            this.vtotal = central.getInverso(ref this.vStotal);
                        }
                        else
                        {
                            this.vtotal = central.getInverso(ref this.vtotal);
                        }
                        break;
                    }
                case ("="):
                    {
                        if (this.isfirst)
                        {                            
                            this.txt1.Text = this.vtotal.ToString();
                        }
                        else
                        {
                            this.txt1.Text = this.vStotal.ToString();
                        }                        
                        
                        this.precalcula(this.current_operand.ToString());
                        this.txt1.Text = this.vtotal.ToString();
                        this.vtotal = 0;
                        this.current_operand = "F";
                        break;
                    }                    
            }

            this.txt2.Text = this.vtotal.ToString();
            this.txt3.Text = this.current_operand;

        }

        private void asigna(string val)
        {
            if (val == "CLS")
            {
                this.txt1.Text = "";
                this.vStotal = 0;
                return;
            }
            if (!(this.txt1.Text.Trim() == "0"))
            {
                if (val == "RET" && this.txt1.Text.Length > 0)
                {
                    this.txt1.Text = this.txt1.Text.Substring(0, this.txt1.Text.Length - 1);
                    return;
                }
                this.txt1.Text += val;
            }
            else
            {
                if (!(val == "RET"))
                {
                    this.txt1.Text = val;
                }
            }
        }
        private void key_listenerBefore(int key)
        {
            if (key == this.cDelKey)
            {
                this.btncls.PerformClick();
                vFlag_key = true;
            }

            if (key == Convert.ToChar(Keys.Enter))
            {
                this.btnequal.PerformClick();
                vFlag_key = true;
            }
        }
        private void key_listener(char keychar)
        {
            if (this.vFlag_key)
            {
                this.vFlag_key = !this.vFlag_key;
                return;
            }
            switch (keychar)
            {
                case '.':
                    {
                        this.btndot.PerformClick();
                        break;
                    }
                case '-':
                    {
                        this.btnrest.PerformClick();
                        break;
                    }
                case '+':
                    {
                        this.btnsum.PerformClick();
                        break;
                    }
                case '/':
                    {
                        this.btndiv.PerformClick();
                        break;
                    }
                case '*':
                    {
                        this.btnmul.PerformClick();
                        break;
                    }
                case '9':
                    {
                        this.btn9.PerformClick();
                        break;
                    }
                case '8':
                    {
                        this.btn8.PerformClick();
                        break;
                    }
                case '7':
                    {
                        this.btn7.PerformClick();
                        break;
                    }
                case '6':
                    {
                        this.btn6.PerformClick();
                        break;
                    }
                case '5':
                    {
                        this.btn5.PerformClick();
                        break;
                    }
                case '4':
                    {
                        this.btn4.PerformClick();
                        break;
                    }
                case '3':
                    {
                        this.btn3.PerformClick();
                        break;
                    }
                case '2':
                    {
                        this.btn2.PerformClick();
                        break;
                    }
                case '1':
                    {
                        this.btn1.PerformClick();
                        break;
                    }
                case '0':
                    {
                        this.btn0.PerformClick();
                        break;
                    }
            }

            if (keychar == this.cBackspacekey)
            {
                this.btnret.PerformClick();
            }
        }
        /// <summary>
        /// Funciones y procedimientos event based
        /// </summary>

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Calculadora";            
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("0");
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            if (!this.txt1.Text.Contains("."))
            {
                if (this.txt1.Text.Trim() == "0")
                {
                    this.asigna("0.");
                }
                else
                {
                    this.asigna(".");
                }
            }
        }

        private void bntmul_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("*");
        }

        private void btnrest_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            if ((!this.txt1.Text.Contains("-")) && (this.txt1.Text.Trim() == "0"))
            {
                this.asigna("-");
            }
            else
            {
                if (this.txt1.Text.Trim() != "-")
                {
                    this.precalcula("-");
                }
            }

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("9");
        }

        private void btnsum_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("+");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("6");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("3");
        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("=");
        }
        private void btncls_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("CLS");
            this.clear_vals();
        }

        private void btninv_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);

            if(this.txt1.Text == String.Empty)
            {
                return;
            }

            this.precalcula("INV");
        }

        private void btnpow3_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("X3");
        }

        private void btnpow2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("X2");
        }

        private void btnsqrt_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("sqrt");
        }

        private void btnmodulo_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
        }

        private void btnret_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.asigna("RET");
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("/");
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msg.show("Desarrollado por: Jesús José Navarrete Baca");
        }

        private void btnsin_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("SIN");
        }

        private void btncos_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)(sender);
            this.precalcula("COS");
        }

        private void btntan_Click(object sender, EventArgs e)
        {
            this.precalcula("TAN");
        }
    }
}
