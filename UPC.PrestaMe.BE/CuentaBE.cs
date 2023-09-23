using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PrestaMe.BE
{
    public class CuentaBE
    {
        public int id_cuenta { get; set; }
        public int id_cliente { get; set; }
        public int id_tipo_cuenta { get; set; }
        public string numero_cuenta { get; set; } = string.Empty;
        public decimal saldo_contable { get; set; }
        public decimal saldo_disponible { get; set; }
        public int id_estado_cuenta { get; set; }
    }
}
