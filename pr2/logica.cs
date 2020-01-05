using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;
using TAREA2.CUSTOM_CONTROLS;

namespace TAREA2
{
    public class logica
    {
        private List<contacto> lst_contactos;
        private contacto usr = default(contacto);

        public logica()
        {
            this.lst_contactos = new List<contacto>() { };
        }

        public void getWhereContacts(ref DGVCustom dgv, string[] filters)
        {
            bool flag = false;
            
            if (filters == null)
            {
                return;
            }
            //Se obtiene bloque origen
            var query = (from t
                        in this.lst_contactos
                         select new
                         {
                             Id = t.id.ToString(),
                             Nombre = t.getNombre() + t.getApellido(),
                             Municipio = t.getMpo(),
                             Estado = t.getEstado(),
                             Pais = t.getPais(),
                             Calle = t.getCalle(),
                             Numero = t.getNumero(),
                             CP = t.getCp().ToString(),
                             Telefono = t.getTelefono()
                         }).ToList();

            //Se arma Query dinamico 
            for (var rIndex = 0; rIndex < filters.Length; ++rIndex)
            {
                if (!(filters[rIndex] != string.Empty))
                {
                    continue;
                }       
                
                if(!flag)
                {
                    flag = !flag;
                }
                switch (rIndex)
                {
                    case (0):
                        {                          
                            query = query.Where(x => x.Nombre.ToUpper().Contains(filters[rIndex].ToUpper())).ToList();
                            break;
                        }
                    case (1):
                        {
                            query = query.Where(x => x.Pais.ToUpper().Contains(filters[rIndex].ToUpper())).ToList();
                            break;

                        }
                    case (2):
                        {
                            query = query.Where(x => x.Estado.ToUpper().Contains(filters[rIndex].ToUpper())).ToList();
                            break;
                        }
                    case (3):
                        {
                            query = query.Where(x => x.Municipio.ToUpper().Contains(filters[rIndex].ToUpper())).ToList();
                            break;
                        }
                    case (4):
                        {
                            query = query.Where(x => x.Telefono.ToUpper().Contains(filters[rIndex].ToUpper())).ToList();
                            break;
                        }
                    case (5):
                        {
                            query = query.Where(x => x.CP.ToUpper().Contains(filters[rIndex].ToUpper())).ToList();
                            break;
                        }
                }

            }
            if (flag)
            {
                dgv.DataSource = query;
            }
            else
            {
                dgv.DataSource = query.Where(x => x.Id == "-33").ToList();
            }
        }
        public void getAllContacts(ref DGVCustom dgv)
        {
            dgv.DataSource = (from t
                              in this.lst_contactos
                              select new
                              {
                                  Id = t.id,
                                  Nombre = t.getNombre() + t.getApellido(),
                                  Municipio = t.getMpo(),
                                  Estado = t.getEstado(),
                                  Pais = t.getPais(),
                                  Calle = t.getCalle(),
                                  Numero = t.getNumero(),
                                  CP = t.getCp(),
                                  Telefono = t.getTelefono()
                              }).ToList();
        }
        public int getCount()
        {
            return this.lst_contactos.Count();
        }

        public bool insert(ref contacto ct)
        {
            this.lst_contactos.Add(ct);
            return true;
        }

        public bool delete(ref contacto ct)
        {
            if (!this.lst_contactos.Remove(ct))
            {
                return false;
            }
            return true;
        }

        public bool alter(ref contacto ct)
        {
            this.lst_contactos.Remove(ct);
            this.lst_contactos.Add(ct);
            return true;
        }

        public void getUsr(ref contacto ct)
        {
            int id = ct.id;

            this.usr = (from t
                       in this.lst_contactos
                        where t.id == id
                        select t).First();
            ct = this.usr;
        }
        public bool isValid(int folio)
        {
            if (this.lst_contactos.Count > 0)
            {
                var res = (from t
                           in this.lst_contactos
                           where t.id == folio
                           select t).First();

                if (!(res == null))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
