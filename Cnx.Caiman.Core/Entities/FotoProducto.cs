using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoProducto
    {
        public long IdFotoProducto { get; set; }
        public int IdFotoProductoIndex { get; set; }
        public int IdProducto { get; set; }
        public int IdZona { get; set; }
        public int IdMapeo { get; set; }
        public string Vc50Nombre { get; set; }
        public int IdTipoProducto { get; set; }
        public int? IClaveSiclo { get; set; }
        public string Vc10ClaveSiclo { get; set; }
        public int? IClaveSit { get; set; }
        public int? IdProductoCopia { get; set; }
        public bool BMensual { get; set; }
        public bool BMensualEntra { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
        public int? IdProd55 { get; set; }
    }
}
