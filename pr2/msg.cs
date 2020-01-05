using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA2
{
    public static class msg
    {
        public static void show(string txt)
        {
            System.Windows.Forms.MessageBox.Show(txt, "Información", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
        public static void danger(string txt)
        {
            System.Windows.Forms.MessageBox.Show(txt, "Atencion,", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
        }
        public static void error(string txt)
        {
            System.Windows.Forms.MessageBox.Show(txt, "Error,", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        public static bool yesno(string ask)
        {
            DialogResult dr = MessageBox.Show(ask, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dr == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }   
    }
}
