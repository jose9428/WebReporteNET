using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;

using WebAPIReporte.Data;

namespace WebAPIReporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {

        private ReporteData data = new ReporteData();

        [HttpGet]
        [Route("listar")]
        public IActionResult getListProducts()
        {
            return Ok(data.getListProducts());
        }


        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            var result = data.GenerateReportProducts();

            return File(result , "application/pdf");
        }

        [HttpGet]
        [Route("test2")]
        public IActionResult Test2()
        {

            //    string RutaCompleta = Directory.GetCurrentDirectory()+"\\Reports\\ReportePrueba.rdlc
            string minType = "";
            int extension = 1;
            var path = "Reports\\ReportePrueba.rdlc";
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            //   parametros.Add("clave" , "valor");
            LocalReport report = new LocalReport(path);
            var result = report.Execute(RenderType.Pdf, extension, null, minType);

            return File(result.MainStream, "application/pdf");
        }
    }
}
