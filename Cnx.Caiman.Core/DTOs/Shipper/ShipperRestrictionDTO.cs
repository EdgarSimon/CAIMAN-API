using System;

namespace Cnx.Caiman.Core.DTOs.Shipper
{
    public class ShipperRestrictionDto
    {
        public int tid { get; set; }
        public string value255 { get; set; }
        public Nullable<bool> bAplicaTodos { get; set; }
        public string vcDatosExcluir { get; set; }
        public string vcClave { get; set; }
    }
}
