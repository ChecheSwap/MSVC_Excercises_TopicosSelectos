using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREA4.CONTROLS
{
    public  class tabModel
    {
        private DataTable dt;
        private UInt64 id = 0;
        public tabModel(ref DGVcustom DGV)
        {
            this.dt = new DataTable();
            this.dt.Columns.Add(new DataColumn("ID", typeof(string)) { ReadOnly = true });
            this.dt.Columns.Add(new DataColumn("Valor", typeof(string)) { ReadOnly = true});            
            DGV.DataSource = this.dt;            
        }

        public void add(string val, ref DGVcustom dgv)
        {
            DataRow dr  = this.dt.NewRow();
            dr["ID"]    = ++this.id;
            dr["Valor"] = val;
            this.dt.Rows.Add(dr);
            dgv.FirstDisplayedScrollingRowIndex = int.Parse((this.id - 1).ToString());
        }

        public void reset()
        {
            this.dt.Clear();
            this.id = 0;            
        }

    }
}
