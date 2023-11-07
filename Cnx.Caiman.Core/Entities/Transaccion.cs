using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Transaccion
    {
        public long Tid { get; set; }
        public string Vc20Desc1 { get; set; }
        public string Vc20Desc2 { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime? DtFinal { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
