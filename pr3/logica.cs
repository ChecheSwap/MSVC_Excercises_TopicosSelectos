using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace TAREA3
{
    public class logica
    {
        private System.Timers.Timer t0 = default(System.Timers.Timer);
        private int vMax, vMin;
        private Random rGen = default(Random);
        private control ct0;
        private Stopwatch sw1;     

        public logica(int pMin, int pMax, control ct0)
        {
            this.vMin = pMin;
            this.vMax = pMax;            

            this.t0 = new System.Timers.Timer(globals.speed);
            this.t0.AutoReset = true;
            this.t0.Elapsed += (sender,e) => { this.ejecuta(); };            

            this.ct0 = ct0;
            this.rGen = new Random();                        
            this.start();            
        }
        public void ejecuta()
        {
            globals.currVal = this.rGen.Next(vMin-globals.constRange,vMax+globals.constRange+1);            
            try
            {
                if (this.ct0.lblView.InvokeRequired)
                {
                    this.ct0.Invoke(new MethodInvoker(delegate
                    {
                        this.ct0.lblView.Text = "Lectura: "+globals.currVal.ToString();
                        this.ct0.lbltime.Text = this.sw1.Elapsed.ToString();
                    }));
                }
            }
            catch(Exception ex)
            {
                this.t0.Stop();
                this.sw1.Stop();          
            }       

            if (globals.currVal > this.vMax || globals.currVal < this.vMin)
            {
                this.t0.Stop();
                globals.state = true;
                this.ct0.check();  
            }
        }
        public void start()
        {
            this.sw1 = new Stopwatch();            
            globals.state = false;
            globals.currVal = 0;

            this.sw1.Start();
            this.t0.Start();            
        }

        public void stop()
        {
            this.t0.Stop();
        }
    }
}
