using Dapper;
using System.Data.SqlClient;
using UPC.PrestaMe.BE;

namespace UPC.PrestaMe.DA
{
    public class ClienteDA
    {
        private readonly SqlConnection conn;
        private readonly AppSettings appSettings;
        public ClienteDA()
        {
            appSettings = new AppSettings();
            conn = new SqlConnection(appSettings.ConnectionString);
        }

        public List<ClienteBE> ListarTodo() {
            var query = "SELECT * FROM Cliente";

            using (conn) {
                var lstClientes = conn.Query<ClienteBE>(query).ToList();
                return lstClientes;
            }
        }

        public ClienteBE_Autenticar Autenticar(string email, string password)
        {
            var query = 
                $"SELECT id_cliente, nombres, apellidos " +
                $"FROM cliente WHERE email = '{email}' AND password = '{password}'";
            var objClienteBE = new ClienteBE_Autenticar();

            using (conn) {
                var cliente = conn.Query(query).ToList();
                objClienteBE = (from c in cliente
                                select new ClienteBE_Autenticar
                                {
                                    id_cliente = c.id_cliente,
                                    nombres = c.nombres,
                                    apellidos = c.apellidos
                                }).Single();
                return objClienteBE;
            }
        }

        public ClienteBE Registrar(ClienteBE objClienteBE) {
            var query = 
                $"INSERT cliente VALUES (" +
                $"'{objClienteBE.nombres}', " +
                $"'{objClienteBE.apellidos}', " +
                $"'{objClienteBE.email}', " +
                $"'{objClienteBE.password}', " +
                $"'{objClienteBE.fecha_nacimiento.ToString("yyyy-MM-dd")}', " +
                $"{objClienteBE.id_doc_identidad}, " +
                $"'{objClienteBE.numero_doc_identidad}') " +
                $"SELECT SCOPE_IDENTITY()";
            using (conn) {
                var id_cliente = conn.QuerySingle<int>(query);
                objClienteBE.id_cliente = id_cliente;
                return objClienteBE;
            }
        }

        public ClienteBE Actualizar(ClienteBE objClienteBE)
        {
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
            using (conn)
            {
                objClienteBE = conn.Query<ClienteBE>(query).Single();
                return objClienteBE;
            }
        }

        public bool Eliminar(int id_cliente) {
            var query = $"DELETE FROM cliente WHERE id_cliente = {id_cliente}";
            using(conn) {
                conn.Execute(query);
                return true;
            }            
        }

        public ClienteBE BuscarPorId(int id_cliente) {
            var query = $"SELECT * FROM cliente WHERE id_cliente = {id_cliente}";
            using (conn)
            {
                ClienteBE objClienteBE = new ClienteBE();
                objClienteBE = conn.QuerySingle<ClienteBE>(query);
                return objClienteBE;
            }
        }
    }
}