using UPC.PrestaMe.BE;
using UPC.PrestaMe.DA;

namespace UPC.PrestaMe.UT
{
    [TestClass]
    public class ClienteUT
    {
        private ClienteDA objClienteDA;
        public ClienteUT()
        {
            objClienteDA = new ClienteDA();
        }

        [TestMethod]
        public void ListarTodo()
        {
            var clientes = objClienteDA.ListarTodo();
            Assert.IsNotNull(clientes);
        }

        [TestMethod]
        public void Autenticar()
        {
            var cliente = objClienteDA.Autenticar("earocas@prestape.com", "123");
            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void Registrar()
        {
            ClienteBE objClienteBE = new ClienteBE {
                nombres = "Genaro",
                apellidos = "Ramos",
                email = "demo@upc.edu.pe",
                password = "123",
                fecha_nacimiento = new DateTime(1991, 1, 8),
                id_doc_identidad = 1,
                numero_doc_identidad = "12345678"
            };
            var cliente = objClienteDA.Registrar(objClienteBE);
            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void Actualizar()
        {
            ClienteBE objClienteBE = new ClienteBE
            {
                id_cliente = 123,
                nombres = "Genaro",
                apellidos = "Ramos",
                email = "demo@upc.edu.pe",
                password = "321",
                fecha_nacimiento = new DateTime(1991, 2, 8),
                id_doc_identidad = 1,
                numero_doc_identidad = "12345678"
            };
            var cliente = objClienteDA.Actualizar(objClienteBE);
            Assert.IsNotNull(cliente);
        }
    }
}