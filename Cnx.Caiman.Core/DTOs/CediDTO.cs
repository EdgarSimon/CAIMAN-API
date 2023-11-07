using System;

namespace Cnx.Caiman.Core.DTOs
{
    public class CediDto
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
