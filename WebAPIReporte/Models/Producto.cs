using System;
using System.Collections.Generic;

namespace WebAPIReporte.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string NomProducto { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }
    }
}
