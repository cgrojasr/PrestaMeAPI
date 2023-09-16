using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PrestaMe.BE;

namespace UPC.PrestaMe.DA
{
    public class CuentaDA
    {
        public IEnumerable<CuentaBE_ListarPorCliente> ListarPorCliente(int id_cliente) {
            var strConn = "Server=DESKTOP-7VCVMOR\\SQLEXPRESS; Database=dbPrestaMe; User Id=sa; Password=password; TrustServerCertificate=true";
            var query = $"SELECT id_cuenta, numero_cuenta, saldo_contable FROM cuenta WHERE id_cliente = {id_cliente}";

            using (var connection = new SqlConnection(strConn))
            {
                var lstCuentasPorCliente = connection.Query<CuentaBE_ListarPorCliente>(query).ToList();
                return lstCuentasPorCliente;
            }
        }
    }
}
