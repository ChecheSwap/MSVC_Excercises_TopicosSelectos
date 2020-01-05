using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREA2
{
    public class contacto
    {
        public int id;
        private string vNombres;
        private string vApellidos;
        private string vTelefono;
        private string vCalle;
        private int vNumero;
        private string vColonia;
        private int vCp;
        private string vMpo;
        private string vPais;
        private string vEstado;
             
        public contacto()
        {            
            this.id = foleador.getNextFolio();                         
        }

        public contacto(string vS)
        {
            this.id = foleador.getCurrFolio();
        }


        public contacto(string vNombres, string vApellidos, string vCalle, int vNumero, string vColonia, int vCp, string vTelefono)
        {
            this.id = foleador.getNextFolio();            

            this.vNombres = vNombres;
            this.vApellidos = vApellidos;
            this.vCalle = vCalle;
            this.vNumero = vNumero;
            this.vColonia = vColonia;
            this.vCp = vCp;
            this.vTelefono = vTelefono;
        }

        /// <summary>
        /// GETTES
        /// </summary>
        /// <returns></returns>
        public string getPais()
        {
            return this.vPais;
        }
        public string getEstado()
        {
            return this.vEstado;
        }
        public string getMpo()
        {
            return this.vMpo;
        }

        public string getNombre()
        {
            return this.vNombres;
        }
        public string getApellido()
        {
            return this.vApellidos;
        }
        public string getCalle()
        {
            return this.vCalle;
        }
        public int getNumero()
        {
            return this.vNumero;
        }
        public string getColonia()
        {
            return this.vColonia;
        }
        public int getCp()
        {
            return this.vCp;
        }
        public string getTelefono()
        {
            return this.vTelefono;
        }

        /// <summary>
        /// SETTES
        /// </summary>
        
        public void setEstado(string edo)
        {
            this.vEstado = edo;
        }
        public void setMpo(string mpo)
        {
            this.vMpo = mpo;
        }
        public void setPais(string pais)
        {
            this.vPais = pais;
        }
        public void setNombre(string nombre)
        {
            this.vNombres = nombre;
        }
        public void setApellido(string apellido)
        {
            this.vApellidos = apellido;
        }
        public void setCalle(string calle)
        {
            this.vCalle = calle;
        }
        public void setNumero(int numero)
        {            
            this.vNumero = numero;
        }
        public void setColonia(string colonia)
        {
            this.vColonia = colonia;
        }
        public void setCp(int cp)
        {
            this.vCp = cp;
        }
        public void setTelefono(string telefono)
        {
            this.vTelefono = telefono;
        }
    }
}
