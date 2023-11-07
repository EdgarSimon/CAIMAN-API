using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class OfertaInventario
    {
        public int IdZona { get; set; }
        public int IdProducto { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NOfertaInventario { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public bool BActualizado { get; set; }
        public decimal? NDemandaFueraAi { get; set; }
    }
}
