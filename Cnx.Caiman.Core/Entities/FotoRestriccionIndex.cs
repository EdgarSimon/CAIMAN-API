using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoRestriccionIndex
    {
        public int IdFotoRestriccionIndex { get; set; }
        public int IdZona { get; set; }
        public string Vc50Nombre { get; set; }
        public string Vc255Observaciones { get; set; }
        public DateTime DtFecha { get; set; }
        public bool BActiva { get; set; }
        public long Tid { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
