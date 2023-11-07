using System;

namespace Cnx.Caiman.Core.DTOs.Origin
{
    public class OriginLocationDto
    {
        public int IdOrigen { get; set; }
        public string VcSap { get; set; }
        public string VcZonaSap { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public bool? BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }

        public virtual OriginDto OriginDTO  { get; set; }
    }
}