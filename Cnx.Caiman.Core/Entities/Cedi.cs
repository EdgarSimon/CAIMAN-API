using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Cedi
    {
        public string VcSap { get; set; }
        public string VcDescripcion { get; set; }
        public bool BActivo { get; set; }
        public string VcUsuarioCreo { get; set; }
        public DateTime DtCreacion { get; set; }
        public string VcUsuarioModifico { get; set; }
        public DateTime DtModificado { get; set; }
    }
}
