using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DamMonClient;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace DamMonClient
{
    class Monitor
    {
        private int interval;

        private string komputer;

        public string Komputer
        {
            get { return this.komputer;  }
            set { this.komputer = value; }
        }
        public int Interval 
        { 
            get { return this.interval; }
            set { this.interval = value; }
        }

        public void RunALL()
        {
            
            DamMonEntities db = new DamMonEntities();
            
            bool done = false;
            PerformanceCounter pcpu = new PerformanceCounter("Procesor", "Czas procesora (%)", "_Total");
            PerformanceCounter pdisk = new PerformanceCounter("Dysk fizyczny", "Średnia długość kolejki dysku", "_Total");
            PerformanceCounter pram = new PerformanceCounter("Pamięć", "Dostępna Pamięć (MB)");
            string nazwaSerwera = this.komputer;
            while (!done)
            {
                Pomiary pom = new Pomiary();
                pom.DataCzasProbki = System.DateTime.Now;
                float fcpu = pcpu.NextValue();
                float fdisk = pdisk.NextValue();
                float fram = pram.NextValue();
                //Console.WriteLine(String.Format("SERWER: {0}, CPU: {1}, DISK: {2}, RAM: {3}", nazwaSerwera, fcpu, fdisk, fram));
                pom.CzasProcesora = fcpu;
                pom.SredniaDlugoscKolejkiDyski = fdisk;
                pom.DostepnaPamiec = fram;
                pom.NazwaSerwera = nazwaSerwera;
                //db.Pomiary.Add(pom);
                //db.SaveChanges();
                WyslijNaSerwer(pom);
                System.Threading.Thread.Sleep(this.interval);
            }
        }

        public void RunCPUTest()
        {
            bool done = false;
            PerformanceCounter pcpu = new PerformanceCounter("Procesor", "Czas procesora (%)", "_Total");
            while (!done)
            {
                float c = pcpu.NextValue();
                Console.WriteLine(String.Format("Czas procesora (%): _Total = {0} \n", c));
                System.Threading.Thread.Sleep(this.interval);
            }
        }

        public void RunDISKTest()
        {
            bool done = false;
            PerformanceCounter pdisk = new PerformanceCounter("Dysk fizyczny", "Średnia długość kolejki dysku", "_Total");
            while (!done)
            {
                float c = pdisk.NextValue();
                Console.WriteLine(String.Format("Średnia długość kolejki dysku: _Total = {0} \n", c));
                System.Threading.Thread.Sleep(this.interval);
            }
        }

        public void RunRAMTest()
        {
            bool done = false;
            PerformanceCounter pram = new PerformanceCounter("Pamięć", "Dostępna Pamięć (MB)");
            while (!done)
            {
                float c = pram.NextValue();
                //Console.WriteLine(String.Format("Dostępna Pamięć (MB): _Total = {0} \n", c));
                System.Threading.Thread.Sleep(this.interval);
            }
        }

        private void WyslijNaSerwer(Pomiary pomiar)
        {
            string url = "http://localhost:16449/Home/TestReq?serwer=" + pomiar.NazwaSerwera;
            HttpWebRequest zadWeb = (HttpWebRequest)WebRequest.Create(url);
            string ret = "";

            using (var odpWeb = (HttpWebResponse)zadWeb.GetResponse())
            {
                using (var reader = new StreamReader(odpWeb.GetResponseStream()))
                {
                    ret = reader.ReadToEnd();
                }
            }
            Console.WriteLine(ret);
        }
    }
}
