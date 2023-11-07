using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoRelUso
    {
        public long IdFotoRelUso { get; set; }
        public int IdFotoRelUsoIndex { get; set; }
        public int IdUso { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public string CClasificacion { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
    }
}
