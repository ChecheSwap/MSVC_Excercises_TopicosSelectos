using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadora
{
    public class msg:Form
    {
        public static void show(string txt)
        {
            MessageBox.Show(txt,"Calculadora", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void danger(string txt)
        {
            MessageBox.Show(txt,"Atencion,",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        public static void error(string txt)
        {
            MessageBox.Show(txt, "Error,", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
