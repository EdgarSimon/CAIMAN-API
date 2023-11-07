using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class VwInventarioListar
    {
        public int Zona { get; set; }
        public int Destino { get; set; }
        public string NomDestino { get; set; }
        public int? Pd { get; set; }
        public int Producto { get; set; }
        public string NomProducto { get; set; }
        public decimal Inventario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
