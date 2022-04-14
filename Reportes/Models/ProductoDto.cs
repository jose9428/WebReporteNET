using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes.Models
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }
        public string NomProducto { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}
