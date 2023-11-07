using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class LogErrorDuplicado
    {
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int? IdZona { get; set; }
        public string IProdM { get; set; }
        public string VcProceso { get; set; }
        public string VcDescripcion { get; set; }
        public DateTime? DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
