using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class InventarioOrigen
    {
        public int IdInventarioOrigen { get; set; }
        public int IdOrigen { get; set; }
        public int IdProducto { get; set; }
        public decimal NCapacidadMaxima { get; set; }
        public decimal NInventarioActual { get; set; }
        public decimal NInventarioEnTransito { get; set; }
        public decimal NInventarioFinal { get; set; }
        public decimal NSalidasPromedio { get; set; }
        public string Vc255Observaciones { get; set; }
        public DateTime DtFecha { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
