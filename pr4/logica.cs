using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace TAREA4
{
    public class logica
    {
        private System.Timers.Timer t0 = default(System.Timers.Timer);
        private int vMax, vMin, vX = default(int);
        private Random rGen = default(Random);
        private control ct0;
        private Stopwatch sw1;     

        public logica(int pMin, int pMax, control ct0)
        {
            this.initialize(pMin, pMax, ct0);
        }
        public logica(int pMin, int pMax, int pX, control ct0)
        {
            this.initialize(pMin,pMax,ct0);
            this.vX = pX;
        }

        private void initialize(int pMin, int pMax, control ct0)
        {
            this.vMin = pMin;
            this.vMax = pMax;
            this.ct0 = ct0;
            this.t0 = new System.Timers.Timer(this.ct0.globals.speed);
            this.t0.AutoReset = true;
            this.t0.Elapsed += (sender, e) => { this.ejecuta(); };

            this.rGen = new Random();
            this.start();
        }
        public void ejecuta()
        {
            this.ct0.globals.currVal = this.rGen.Next(vMin- this.ct0.globals.constRange,vMax+ this.ct0.globals.constRange+1);            
            try
            {
                if (this.ct0.lblView.InvokeRequired)
                {
                    this.ct0.Invoke(new MethodInvoker(delegate
                    {
                        this.ct0.lblView.Text = "Lectura: "+ this.ct0.globals.currVal.ToString();
                        this.ct0.lbltime.Text = this.sw1.Elapsed.ToString();
                        this.ct0.updateGrid(this.ct0.globals.currVal.ToString());
                    }));
                }
            }
            catch(Exception ex)
            {
                this.t0.Stop();
                this.sw1.Stop();          
            }
            if (this.vX != default(int))
            {
                if (this.ct0.globals.currVal > this.vMax || this.ct0.globals.currVal < this.vMin || this.ct0.globals.currVal == this.vX)
                {
                    this.t0.Stop();
                    this.ct0.globals.state = true;
                    this.ct0.check();
                }
            }
            else
            {
                if (this.ct0.globals.currVal > this.vMax || this.ct0.globals.currVal < this.vMin)
                {
                    this.t0.Stop();
                    this.ct0.globals.state = true;
                    this.ct0.check();
                }
            }
        }
        public void start()
        {
            this.sw1 = new Stopwatch();
            this.ct0.globals.state = false;
            this.ct0.globals.currVal = 0;

            this.sw1.Start();
            this.t0.Start();            
        }

        public void stop()
        {
            this.t0.Stop();
        }
    }
}
