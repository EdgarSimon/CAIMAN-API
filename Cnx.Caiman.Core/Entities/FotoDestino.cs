using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoDestino
    {
        public long IdFotoDestino { get; set; }
        public int IdFotoDestinoIndex { get; set; }
        public int IdDestino { get; set; }
        public int IdZona { get; set; }
        public int IdMapeo { get; set; }
        public string Vc50Nombre { get; set; }
        public int IManiana { get; set; }
        public int ITarde { get; set; }
        public int INoche { get; set; }
        public bool BEsCliente { get; set; }
        public int? IdDestinoCopia { get; set; }
        public bool BMensual { get; set; }
        public bool BMensualEntra { get; set; }
        public bool BActivo { get; set; }
        public int IdSubZona { get; set; }
        public int? IClaveSicadi { get; set; }
        public int? IClaveSiclo { get; set; }
        public int? IClaveSit { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
        public string Vc12ClaveSap { get; set; }
        public string Cedis { get; set; }
        public string VcZonaSap { get; set; }
    }
}
