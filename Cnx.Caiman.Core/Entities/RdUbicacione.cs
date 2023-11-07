using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RdUbicacione
    {
        public string Vc50IdSap { get; set; }
        public string Vc50Nombre { get; set; }
        public string TipoUbicacion { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string Zt { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
