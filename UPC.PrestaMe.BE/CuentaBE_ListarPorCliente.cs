using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PrestaMe.BE
{
    public class CuentaBE_ListarPorCliente
    {
        public int id_cuenta { get; set; }
        public string numero_cuenta { get; set; } = string.Empty;
        public decimal saldo_disponible { get; set; }
    }
}
