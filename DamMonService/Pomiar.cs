using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamMonService
{
    public partial class Pomiar
    {
        public Nullable<double> CzasProcesora { get; set; }
        public Nullable<double> SredniaDlugoscKolejkiDyski { get; set; }
        public Nullable<double> DostepnaPamiec { get; set; }
        public Nullable<System.DateTime> DataCzasProbki { get; set; }
        public string NazwaSerwera { get; set; }
        public Nullable<int> SerwerID { get; set; }
    }
}
