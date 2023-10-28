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

            using (conn)
            {
                conn.Open();
                var lstCuentasPorCliente = conn.Query<CuentaBE_ListarPorCliente>(query).ToList();
                return lstCuentasPorCliente;
            }
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

            objCuentaBE.id_cuenta = conn.Query<int>(query).Single();            
            return objCuentaBE;
        }

        public void RegistrarNumeroCuenta(int id_cuenta, string numero_cuenta)
        {
            using(conn)
            {
                var query =
                $"UPDATE cuenta SET " +
                $"numero_cuenta = '{numero_cuenta}' " +
                $"WHERE id_cuenta = {id_cuenta}";

                conn.Execute(query);
            }
        }
    }
}
