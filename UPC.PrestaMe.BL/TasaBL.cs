using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PrestaMe.BE;
using UPC.PrestaMe.DA;

namespace UPC.PrestaMe.BL
{
    public class TasaBL
    {
        private readonly TasaDA objTasaDA;
        public TasaBL()
        {
            objTasaDA = new TasaDA();
        }

        public TasaBE_Activa Obtener_RangoActivo() { 
            return objTasaDA.Obtener_RangoActivo();
        }
    }
}
