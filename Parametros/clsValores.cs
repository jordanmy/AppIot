using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIot
{
    public class clsValores
    {
        private string horas = ("00:01-09:00;09:01-18:00;18:01-00:00");
        private string precioLunesViernes = ("25;15;20");
        private string preciosabadoDomingo = ("30;20;25");

        public string Horas { get => horas; set => horas = value; }
        public string PrecioLunesViernes { get => precioLunesViernes; set => precioLunesViernes = value; }
        public string PreciosabadoDomingo { get => preciosabadoDomingo; set => preciosabadoDomingo = value; }

        public clsValores()
        {

        }

    }
}
