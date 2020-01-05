using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA2
{
    public partial class Form1 : Form
    {
        private logica logic;
        private contacto currUsr;
        private string form_status;
        private DataTable tabla = default(DataTable);
        private bool header_status = false;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.KeyUp += (sender, args) =>
          {
              if (args.KeyData == Keys.F2)
              {
                  this.save();
              }
              if (args.KeyData == Keys.F3)
              {
                  this.delete();
              }
          };
            this.txtid.PreviewKeyDown += (sender, args) =>
           {
               if (args.KeyData == Keys.Tab)
               {
                   this.loaduser();
               }
           };
            this.txtid.LostFocus += (sender, args) =>
            {                
                this.loaduser();
            };

            txtonlynumbers.onlyNumbers(ref this.txtcp);
            txtonlynumbers.onlyNumbers(ref this.txttelefono);
            txtonlynumbers.onlyNumbers(ref this.txttelefonofilter);
            txtonlynumbers.onlyNumbers(ref this.txtcpfilter);
            this.form_status = "NEW";

            this.tabla = new DataTable();
            this.tabla.Columns.Add("Id");
            this.tabla.Columns.Add("Nombre");
            this.tabla.Columns.Add("Municipio");
            this.tabla.Columns.Add("Estado");
            this.tabla.Columns.Add("Pais");
            this.tabla.Columns.Add("CP");
            this.tabla.Columns.Add("Telefono");

            this.dgv.DataSource = this.tabla;
            this.dgv.KeyPress += (sender, args) =>
            {
                this.passDataHeader();
            };
            this.dgv.DoubleClick += (sender, args) =>
            {
                this.passDataHeader();
            };
            this.txtnombrefilter.KeyUp += (sender, e) =>
            {
                this.filldgv("FILTER");
            };
            this.txtpaisfilter.KeyUp += (sender, e) =>
            {
                this.filldgv("FILTER");
            };
            this.txtestadofilter.KeyUp += (a, b) =>
            {
                this.filldgv("FILTER");
            };
            this.txtmunicipiofilter.KeyUp += (a, b) =>
            {
                this.filldgv("FILTER");
            };
            this.txttelefonofilter.KeyUp += (a, b) =>
            {
                this.filldgv("FILTER");
            };
            this.txtcpfilter.KeyUp += (a, b) =>
            {
                this.filldgv("FILTER");
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.logic = new logica();
            this.refresh();
            this.filldgv();
            this.Text = "Directorio Telefonico";
        }
        /// <summary>
        /// User defined procs
        /// </summary>
        /// 
        private void passDataHeader()
        {
            if (this.header_status)
            {
                msg.danger("Confirme cambios en paso a cabecera actual.");
                this.txtnombre.Focus();
                return;
            }
            if (dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value != null)
            {
                this.txtid.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
                this.loaduser();
                this.header_status = true;
                this.txtid.Enabled = false;
            }
            else
            {
                msg.danger("No se puden pasar datos a cabecero.");
                this.txtid.Focus();
            }
        }
        private void save()
        {
            if (this.fill())
            {
                if (this.form_status == "NEW")
                {
                    if (this.logic.insert(ref this.currUsr))
                    {
                        msg.show("Contacto Guardado");
                        this.refresh();
                        this.filldgv("ALL");
                    }
                    else
                    {
                        msg.danger("No se ha podido guardar el usuario, cheque valores...");
                        this.txtid.Focus();
                    }
                }
                else if (this.form_status == "QUERY")
                {
                    if (this.logic.alter(ref this.currUsr))
                    {
                        msg.show("Contacto Actualizado.");
                        this.header_status = false;
                        this.txtid.Enabled = true;
                        this.refresh();
                    }

                }
            }
        }

        private void refresh()
        {

            if (this.form_status == "NEW")
            {
                this.currUsr = new contacto();
            }
            else
            {
                this.currUsr = new contacto("PRAGMA");
            }
            this.txtid.Enabled = true;
            this.header_status = false;
            this.form_status = "NEW";
            this.asign();
            this.filldgv();
            this.txtid.Focus();
        }

        private void asign()
        {
            this.txtid.Text = this.currUsr.id.ToString();
            this.txtnombre.Text = this.currUsr.getNombre();
            this.txtapellido.Text = this.currUsr.getApellido();
            this.txttelefono.Text = this.currUsr.getTelefono();
            this.txtcalle.Text = this.currUsr.getCalle();
            this.txtcolonia.Text = this.currUsr.getColonia();
            this.txtnumero.Text = this.currUsr.getNumero().ToString();
            this.cbmpo.Text = this.currUsr.getMpo();
            this.cbestado.Text = this.currUsr.getEstado();
            this.cbpais.Text = this.currUsr.getPais();
            this.txtcp.Text = this.currUsr.getCp().ToString();
        }

        private bool fill()
        {
            bool tmp = false;
            if (this.txtid.Text == string.Empty)
            {
                msg.danger("ID invalido.");
                this.txtid.Focus();
                return false;
            }
            this.currUsr.setNombre(this.txtnombre.Text);
            this.currUsr.setApellido(this.txtapellido.Text);
            if (this.txttelefono.Text != string.Empty)
            {
                try
                {
                    Int64.Parse(this.txttelefono.Text);

                    if (this.txttelefono.Text.Length == 10)
                    {
                        this.currUsr.setTelefono(this.txttelefono.Text);
                    }
                    else
                    {
                        tmp = !tmp;
                    }
                }
                catch (Exception e)
                {
                    tmp = !tmp;
                }
                finally
                {
                    if (tmp)
                    {
                        msg.danger("Ingrese numero de telefono correcto.");
                        this.txttelefono.Focus();
                    }
                }
                if (tmp)
                {
                    return false;
                }
            }
            else
            {
                msg.danger("Ingrese numero de telefono, es campo requerido.");
                this.txttelefono.Focus();
                return false;
            }
            this.currUsr.setCalle(this.txtcalle.Text);
            this.currUsr.setColonia(this.txtcolonia.Text);
            if (this.txtnumero.Text != string.Empty)
            {
                try
                {
                    this.currUsr.setNumero(int.Parse(this.txtnumero.Text));
                }
                catch (Exception e)
                {
                    msg.danger("Formato de numero Incorrecto, Corrija..");
                    this.txtnumero.Focus();
                    return false;
                }
            }
            this.currUsr.setMpo(this.cbmpo.Text);
            this.currUsr.setEstado(this.cbestado.Text);
            this.currUsr.setPais(this.cbpais.Text);
            if (this.txtcp.Text != string.Empty)
            {
                try
                {
                    this.currUsr.setCp(int.Parse(this.txtcp.Text));
                }
                catch (Exception e)
                {
                    msg.danger("Formato de codigo postal incorrecto, Corrija..");
                    this.txtcp.Focus();
                    return false;
                }
            }
            else
            {
                msg.danger("Ingrese CP, es campo requerido.");
                this.txtcp.Focus();
                return false;
            }
            return true;
        }
        private void loaduser()
        {
            if (!this.header_status)
            {
                try
                {
                    if (this.logic.isValid(int.Parse(this.txtid.Text)))
                    {
                        this.form_status = "QUERY";
                        this.currUsr.id = int.Parse(this.txtid.Text);
                        this.logic.getUsr(ref this.currUsr);
                        this.asign();
                    }
                    else
                    {
                        this.txtid.Text = foleador.getCurrFolio().ToString();
                        this.form_status = "NEW";
                    }
                }
                catch (Exception e)
                {
                    this.txtid.Text = this.currUsr.id.ToString();
                }
            }
        }
        private void delete()
        {
            if (this.form_status == "QUERY")
            {
                if (this.txtid.Text != string.Empty)
                {
                    try
                    {
                        if (this.logic.isValid(int.Parse(this.txtid.Text)))
                        {
                            if (msg.yesno("Confirma la eliminación del usuario con ID: " + this.txtid.Text + "?"))
                            {
                                if (this.logic.delete(ref this.currUsr))
                                {
                                    msg.show("Se ha eliminado a: " + this.currUsr.getNombre() + " " + this.currUsr.getApellido());
                                    this.form_status = "DELETE";
                                    this.refresh();
                                }
                                else
                                {
                                    msg.danger("No se ha podido eliminar el contacto, intente de nuevo.");
                                }
                            }
                        }
                        else
                        {
                            msg.danger("Contacto no valido.");
                        }
                    }
                    catch (Exception e)
                    {
                        msg.danger("*Error con formato de Identificador");
                    }
                }
                else
                {
                    msg.danger("Operacion no valida.");
                }
            }
            else
            {
                msg.danger("Operacion no valida.");
            }
            this.txtid.Focus();
        }

        private void filldgv(string type = "ALL")
        {
            switch (type)
            {
                case "ALL":
                    {
                        this.logic.getAllContacts(ref this.dgv);
                        break;
                    }
                case "FILTER":
                    {
                        string[] vFilter = new string[6];
                        vFilter[0] = this.txtnombrefilter.Text.Trim();
                        vFilter[1] = this.txtpaisfilter.Text.Trim();
                        vFilter[2] = this.txtestadofilter.Text.Trim();
                        vFilter[3] = this.txtmunicipiofilter.Text.Trim();
                        vFilter[4] = this.txttelefonofilter.Text.Trim();
                        vFilter[5] = this.txtcpfilter.Text.Trim();
                        this.logic.getWhereContacts(ref this.dgv,vFilter);
                        break;
                    }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            this.filldgv("FILTER");
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            this.filldgv();
        }
    }
}
