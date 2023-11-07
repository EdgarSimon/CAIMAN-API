using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class OfertaTransportePronostico
    {
        public int IdOfertaTransportePron { get; set; }
        public int IdTransportista { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NOfertaPronosticada { get; set; }
        public decimal NOfertaColaborada { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
