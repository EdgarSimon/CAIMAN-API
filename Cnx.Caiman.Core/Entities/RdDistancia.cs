using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RdDistancia
    {
        public string Vc50IdSap1 { get; set; }
        public string Vc50Nombre1 { get; set; }
        public string TipoUbicacion1 { get; set; }
        public double? Lat1 { get; set; }
        public double? Lon1 { get; set; }
        public string Zt1 { get; set; }
        public string Vc50IdSap2 { get; set; }
        public string Vc50Nombre2 { get; set; }
        public string TipoUbicacion2 { get; set; }
        public double? Lat2 { get; set; }
        public double? Lon2 { get; set; }
        public string Zt2 { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public double? DistLr { get; set; }
        public double? DistFactor { get; set; }
    }
}
