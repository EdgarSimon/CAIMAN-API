using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoOfertaPronostico
    {
        public long IdFotoOfertaPronostico { get; set; }
        public int IdOfertaPronostico { get; set; }
        public int IdOrigen { get; set; }
        public int IdProducto { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NOfertaPronosticada { get; set; }
        public decimal NOfertaColaborada { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
        public int IReferenciaFoto { get; set; }
        public decimal? NViaje { get; set; }
    }
}
