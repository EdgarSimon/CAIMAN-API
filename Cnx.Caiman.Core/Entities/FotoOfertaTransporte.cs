using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoOfertaTransporte
    {
        public long IdFotoOfertaTransporte { get; set; }
        public int IdFotoOfertaTransporteIndex { get; set; }
        public int IdOfertaTransporte { get; set; }
        public int IdTransportista { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NOfertaTotal { get; set; }
        public decimal NAsignadoTotal { get; set; }
        public decimal NDisponibleTotal { get; set; }
        public string Vc255Observaciones { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
    }
}
