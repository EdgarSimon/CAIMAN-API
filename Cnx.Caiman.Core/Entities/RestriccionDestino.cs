using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RestriccionDestino
    {
        public int IdRestriccionDestino { get; set; }
        public int IdRestriccion { get; set; }
        public int IdDestino { get; set; }
        public int BRestriccion2 { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
    }
}
