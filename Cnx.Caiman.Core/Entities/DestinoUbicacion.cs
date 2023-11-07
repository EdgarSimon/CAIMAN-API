using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class DestinoUbicacion
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

        public virtual Destino IdDestinoNavigation { get; set; }
    }
}
