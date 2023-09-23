using UPC.PrestaMe.BE;
using UPC.PrestaMe.DA;

namespace UPC.PrestaMe.BL
{
    public class ClienteBL
    {
        private readonly ClienteDA objClienteDA;
        public ClienteBL()
        {
            objClienteDA = new ClienteDA();
        }

        public ClienteBE_Autenticar Autenticar(string email, string contrasena) {
            try
            {
                return objClienteDA.Autenticar(email, contrasena);
            }
            catch (Exception)
            {
                return new ClienteBE_Autenticar
                {
                    id_cliente = 0,
                    nombres = string.Empty,
                    apellidos = string.Empty,
                };
            }
        }

        public IEnumerable<ClienteBE> ListarTodo() {
            try
            {
                return objClienteDA.ListarTodo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteBE BuscarPorId(int id_cliente)
        {
            try
            {
                return objClienteDA.BuscarPorId(id_cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}