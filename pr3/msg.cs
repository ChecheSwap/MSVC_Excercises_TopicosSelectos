using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA3
{
    public static class msg
    { 
        public static void show(string msg)
        {
            MessageBox.Show(msg,"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void err(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }
        public static void danger(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static bool exit()
        {
            DialogResult res = MessageBox.Show("Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(res == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
    }
}
