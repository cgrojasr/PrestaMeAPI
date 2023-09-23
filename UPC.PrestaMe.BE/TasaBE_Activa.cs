using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PrestaMe.BE
{
    public class TasaBE_Activa
    {
        public int id_tasa_rango { get; set; }
        public decimal tasa_minimo { get; set; }
        public decimal tasa_maximo { get; set; }
    }
}
