using System;

namespace Cnx.Caiman.Core.DTOs.Destination
{
    public class DestinationLocationDto
    {
        public int IdDestino { get; set; }
        public string Vc12ClaveSap { get; set; }
        public string VcZonaSap { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public bool? BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }

        public virtual DestinationDto IdDestinoNavigation { get; set; }
    }
}