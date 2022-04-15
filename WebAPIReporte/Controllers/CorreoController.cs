using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIReporte.Data;

namespace WebAPIReporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreoController : ControllerBase
    {

        [HttpGet]
        [Route("enviar")]
        public IActionResult EnvioCorreo(string correo)
        {
            CorreoData data = new CorreoData();

            return Ok(data.EnviarCorreoHtml2(correo));
        }

    }
}
