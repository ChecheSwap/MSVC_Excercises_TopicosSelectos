using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA2
{
    public static class txtonlynumbers
    {
        private static bool flag = false;
        public static void onlyNumbers(ref TextBox txt)
        {
            txt.KeyPress += (sender, args) =>
            {
                if (flag)
                {                    
                    return;
                }
                try
                {
                    int y = int.Parse(args.KeyChar.ToString());                    
                }   
                catch(Exception e)
                {                    
                    args.Handled = true;
                }                         
            };
            txt.KeyDown += (sender, args) =>
            {
                if(args.KeyValue == 8)
                {
                    flag = true;                    
                }
                else{
                    flag = false;
                }
            };
        }
            
    }
}
