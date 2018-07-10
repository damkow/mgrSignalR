using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DamMonService;

namespace DamMonService
{
    public partial class MonitorService : ServiceBase
    {
        private Monitor monitor = new Monitor();
        

        public MonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            int interwal = 10000;
            string nazwaKomp = Environment.MachineName;
            
            monitor.Interval = interwal;
            monitor.Komputer = nazwaKomp;
            Task retMon = Task.Factory.StartNew(monitor.RunALL);
        }

        protected override void OnStop()
        {
        }

        
    }
}
