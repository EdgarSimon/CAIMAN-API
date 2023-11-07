using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TarifaPonderadasClasificacion
    {
        public string IOrg { get; set; }
        public string IDst { get; set; }
        public int IdZona { get; set; }
        public int? IdClasificacion { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
    }
}
