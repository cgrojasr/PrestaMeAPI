using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PrestaMe.BE;
using UPC.PrestaMe.DA;

namespace UPC.PrestaMe.BL
{
    public class CuentaBL
    {
        private readonly CuentaDA objCuentaDA;
        public CuentaBL()
        {
            objCuentaDA = new CuentaDA();
        }

        public IEnumerable<CuentaBE_ListarPorCliente> ListarPorCliente(int id_cuenta) {
            try
            {
                return objCuentaDA.ListarPorCliente(id_cuenta);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public CuentaBE Registrar(CuentaBE objCuentaBE) {
            try
            {
                return objCuentaDA.Registrar(objCuentaBE);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
