using AspNetCore.Reporting;
using System.Text;
using WebAPIReporte.Models;
using System.ComponentModel;
using System.Data;

namespace WebAPIReporte.Data
{
    public class ReporteData
    {
        public List<Producto> getListProducts()
        {
            using (var db = new DBProductoContext())
            {
                return db.Productos.ToList();
            }
        }

        public byte[] GenerateReportProducts()
        {
            var ruta = "Reports\\ReporteProducto.rdlc";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            LocalReport report = new LocalReport(ruta);
            report.AddDataSource("DataSet1", getListProducts());
            var result = report.Execute(RenderType.Pdf, 1, null);
            return result.MainStream;
        }

        public byte[] GenerateReportTest()
        {
            var ruta = "Reports\\ReportePrueba.rdlc";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            LocalReport report = new LocalReport(ruta);
            var result = report.Execute(RenderType.Pdf, 1, null);
            return result.MainStream;
        }

        public DataTable ConvertTo<T>(IList<T> list)
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

        public DataTable CreateTable<T>()
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
