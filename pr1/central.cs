using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadora
{
    public static class central
    {
        public static double getsuma(ref double n1, ref double n2)
        {
            return Math.Round(n1 + n2,5);
        }

        public static double getdivide(ref double n1, ref double n2)
        {
            return Math.Round(n1 / n2,5);
        }

        public static double getresta(ref double n1, ref double n2)
        {
            return Math.Round(n1 - n2,5);
        }

        public static double getmultiplica(ref double n1, ref double n2)
        {
            return Math.Round(n1 * n2,5);
        }

        public static double getseno(ref double n)
        {
            return Math.Round(Math.Sin(n),5);
        }

        public static double getcoseno(ref double n)
        {
            return Math.Round(Math.Cos(n),5);
        }

        public static double gettangente(ref double n)
        {
            return Math.Round(Math.Tan(n),5);
        }

        public static double getInverso(ref double n)
        {
            return 1 / n;
        }

        public static double getpow3(ref double n)
        {
            return Math.Pow(n,3);
        }
        public static double getpow2(ref double n)
        {
            return Math.Pow(n, 2);
        }
        public static double getsqrt(ref double n)
        {
            return Math.Sqrt(n);
        }
    }
}
