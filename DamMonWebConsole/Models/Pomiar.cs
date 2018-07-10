using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamMonWebConsole.Models
{
    public class Pomiar
    {
        public int ID {get;set;}

        public float CzasProcesora {get;set;}
        public float SredniaDlugoscKolejkiDyski {get;set;}
        public float DostepnaPamiec {get;set;}
        public DateTime DataCzasProbki {get;set;}

        public string NazwaSerwera { get; set; }

        public int SerwerID { get; set; }
    }
}