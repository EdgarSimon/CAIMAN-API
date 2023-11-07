using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Hour
{
    public class HourRestrictionDto
    {
        public int tid { get; set; }
        public string value255 { get; set; }
        public Nullable<bool> bAplicaTodos { get; set; }
        public string vcDatosExcluir { get; set; }
        public string vcClave { get; set; }
    }
}
