using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREA2
{
    public static class foleador
    {
        private static int folio = 0;

        public static int getNextFolio()
        {            
            return folio+=1;
        }

        public static int getCurrFolio()
        {
            return folio;
        }
    }
}
