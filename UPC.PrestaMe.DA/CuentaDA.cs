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
        private readonly SqlConnection conn;
        private readonly AppSettings appSettings;
        public CuentaDA() {
            appSettings = new AppSettings();
            conn = new SqlConnection(appSettings.ConnectionString);
        }

        public IEnumerable<CuentaBE_ListarPorCliente> ListarPorCliente(int id_cliente) {
            var query = 
                $"SELECT id_cuenta, numero_cuenta, saldo_contable " +
                $"FROM cuenta " +
                $"WHERE id_cliente = {id_cliente}";

            conn.Open();
            var lstCuentasPorCliente = conn.Query<CuentaBE_ListarPorCliente>(query).ToList();
            conn.Close();
            return lstCuentasPorCliente;
        }

        public CuentaBE Registrar(CuentaBE objCuentaBE) {
            var query = 
                $"INSERT cuenta VALUES (" +
                $"{objCuentaBE.id_cliente}, " +
                $"{objCuentaBE.id_tipo_cuenta}, " +
                $"{objCuentaBE.numero_cuenta}, " +
                $"{objCuentaBE.saldo_contable}, " +
                $"{objCuentaBE.saldo_disponible}, " +
                $"{objCuentaBE.id_estado_cuenta}) " +
                $"SELECT SCOPE_IDENTITY()";

            conn.Open();
            objCuentaBE.id_cuenta = conn.Query<int>(query).Single();
            conn.Close();
            return objCuentaBE;
        }
    }
}
