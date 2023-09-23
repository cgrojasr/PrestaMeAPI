using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPC.PrestaMe.BE;
using UPC.PrestaMe.BL;

namespace UPC.PrestaMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly CuentaBL objCuentaBL;

        public CuentaController()
        {
            objCuentaBL = new CuentaBL();
        }

        [HttpGet("{id_cliente}")]
        public IActionResult ListarPorCliente(int id_cliente) {
            return Ok(objCuentaBL.ListarPorCliente(id_cliente));
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] CuentaBE objCuentaBE) { 
            return Ok(objCuentaBL.Registrar(objCuentaBE));
        }
    }
}
