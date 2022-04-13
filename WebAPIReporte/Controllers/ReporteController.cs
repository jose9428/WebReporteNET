using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data;

namespace WebAPIReporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
 
            string RutaCompleta = Directory.GetCurrentDirectory()+"\\Reports\\ReportePrueba.rdlc";
     
            string minType = "";
            int extension = 1;
            var path = "Reports\\ReportePrueba.rdlc";
            Dictionary<string, string> parametros = new Dictionary<string, string>();
         //   parametros.Add("clave" , "valor");
            LocalReport report = new LocalReport(path);
            var result = report.Execute(RenderType.Pdf , extension, parametros , minType);

            return File(result.MainStream , "application/pdf");
        }

        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor prop in properties)
            {
                // HERE IS WHERE THE ERROR IS THROWN FOR NULLABLE TYPES
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
            prop.PropertyType) ?? prop.PropertyType);
            }
            return table;
        }
    }
}
