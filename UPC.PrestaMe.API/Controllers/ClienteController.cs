using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPC.PrestaMe.API.Models;
using UPC.PrestaMe.BE;
using UPC.PrestaMe.BL;

namespace UPC.PrestaMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteBL objCLienteBL;
        public ClienteController()
        {
            objCLienteBL = new ClienteBL();
        }

        [HttpPost]
        public IActionResult Autenticar([FromBody] ClienteModel_Autenticar objCliente_Autenticar) {
            try
            {
                return Ok(objCLienteBL.Autenticar(objCliente_Autenticar.email, objCliente_Autenticar.password));
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        [HttpGet]
        public IActionResult ListarTodo() {
            try
            {
                return Ok(objCLienteBL.ListarTodo());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id_cliente}")]
        public IActionResult BuscarPorId(int id_cliente)
        {
            try
            {
                return Ok(objCLienteBL.BuscarPorId(id_cliente));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
