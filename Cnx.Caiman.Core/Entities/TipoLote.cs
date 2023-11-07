using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TipoLote
    {
        public int IdTipoLote { get; set; }
        public string Vc50Nombre { get; set; }
        public bool BActivo { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtActualizacion { get; set; }
    }
}
