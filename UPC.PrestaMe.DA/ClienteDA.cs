using Dapper;
using System.Data.SqlClient;
using UPC.PrestaMe.BE;

namespace UPC.PrestaMe.DA
{
    public class ClienteDA
    {
        //private readonly IConfiguration _configuration;
        //public ClienteDA(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public List<dynamic> ListarTodo() {
            var strConn = "Server=DESKTOP-7VCVMOR\\SQLEXPRESS; Database=dbPrestaMe; User Id=sa; Password=password; TrustServerCertificate=true";
            var query = "SELECT * FROM Cliente";

            using (var connection = new SqlConnection(strConn))
            {
                var lstClientes = connection.Query(query).ToList();
                return lstClientes;
            }
        }

        public ClienteBE_Autenticar Autenticar(string email, string password)
        {
            var strConn = "Server=DESKTOP-7VCVMOR\\SQLEXPRESS; Database=dbPrestaMe; User Id=sa; Password=password; TrustServerCertificate=true";
            var query = String.Format("SELECT id_cliente, nombres, apellidos FROM cliente WHERE email = '{0}' AND password = '{1}'", email, password);
            var objClienteBE = new ClienteBE_Autenticar();
            using (var connection = new SqlConnection(strConn))
            {
                var cliente = connection.Query(query).ToList();
                objClienteBE = (from c in cliente
                                select new ClienteBE_Autenticar
                                {
                                    id_cliente = c.id_cliente,
                                    nombres = c.nombres,
                                    apellidos = c.apellidos
                                }).Single();
            }
            return objClienteBE;
        }

        public ClienteBE Registrar(ClienteBE objClienteBE) {
            var strConn = "Server=DESKTOP-7VCVMOR\\SQLEXPRESS; Database=dbPrestaMe; User Id=sa; Password=password; TrustServerCertificate=true";
            var query = $"INSERT cliente VALUES ('{objClienteBE.nombres}', '{objClienteBE.apellidos}', '{objClienteBE.email}', '{objClienteBE.password}', '{objClienteBE.fecha_nacimiento.ToString("yyyy-MM-dd")}', {objClienteBE.id_doc_identidad}, '{objClienteBE.numero_doc_identidad}') SELECT SCOPE_IDENTITY()";
            using (var connection = new SqlConnection(strConn))
            {
                var id_cliente = connection.QuerySingle<int>(query);
                objClienteBE.id_cliente = id_cliente;
            }
            return objClienteBE;
        }

        public ClienteBE Actualizar(ClienteBE objClienteBE)
        {
            var strConn = "Server=DESKTOP-7VCVMOR\\SQLEXPRESS; Database=dbPrestaMe; User Id=sa; Password=password; TrustServerCertificate=true";
            var query = 
                $"UPDATE cliente SET " +
                $"nombres = '{objClienteBE.nombres}', " +
                $"apellidos = '{objClienteBE.apellidos}', " +
                $"email = '{objClienteBE.email}', " +
                $"password = '{objClienteBE.password}', " +
                $"fecha_nacimiento = '{objClienteBE.fecha_nacimiento.ToString("yyyy-MM-dd")}', " +
                $"id_doc_identidad = {objClienteBE.id_doc_identidad}, " +
                $"numero_doc_identidad = '{objClienteBE.numero_doc_identidad}' " +
                $"WHERE id_cliente = {objClienteBE.id_cliente} " +
                $"SELECT * FROM cliente WHERE id_cliente = {objClienteBE.id_cliente}";
            using (var connection = new SqlConnection(strConn))
            {
                objClienteBE = connection.Query<ClienteBE>(query).Single();
            }
            return objClienteBE;
        }

        public bool Eliminar(int id_cliente) {
            var strConn = "Server=DESKTOP-7VCVMOR\\SQLEXPRESS; Database=dbPrestaMe; User Id=sa; Password=password; TrustServerCertificate=true";
            var query = $"DELETE FROM cliente WHERE id_cliente = {id_cliente}";
            using(var connection = new SqlConnection(strConn)) { 
                connection.Execute(query);
            }
            return true;
        }
    }
}