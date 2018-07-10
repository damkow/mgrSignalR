using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DamMonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int inte = 5000;
            Monitor m1 = new Monitor();
            m1.Interval = inte;
            m1.Komputer = "TEST1";

            Monitor m2 = new Monitor();
            m2.Interval = inte;
            m2.Komputer = "TEST2";

            Monitor m3 = new Monitor();
            m3.Interval = inte;
            m3.Komputer = Environment.MachineName;


            Task p1 = Task.Factory.StartNew(m1.RunALL);
            Task p2 = Task.Factory.StartNew(m2.RunALL);
            Task p3 = Task.Factory.StartNew(m3.RunALL);

            Task.WaitAll(new[] { p1, p2, p3 });
            //Task CPU = Task.Factory.StartNew(m1.RunCPUTest);
            //Task DISK = Task.Factory.StartNew(m1.RunDISKTest);
            //Task RAM = Task.Factory.StartNew(m1.RunRAMTest);
            //Task.WaitAll(new[] { CPU, DISK, RAM });
            //m1.RunALL();
        }
    }
}
