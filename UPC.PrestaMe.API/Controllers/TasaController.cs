using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPC.PrestaMe.BE;
using UPC.PrestaMe.BL;

namespace UPC.PrestaMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasaController : ControllerBase
    {
        private readonly TasaBL objTasaBL;

        public TasaController()
        {
            objTasaBL = new TasaBL();
        }

        [HttpGet]
        public IActionResult Obtener_RangoActivo() { 
            return Ok(objTasaBL.Obtener_RangoActivo());
        }
    }
}
