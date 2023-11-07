using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TarifaJerarquiaInterfaz
    {
        public int IAux { get; set; }
        public string Pta { get; set; }
        public string IOrg { get; set; }
        public string IDst { get; set; }
        public string J1 { get; set; }
        public string J2 { get; set; }
        public string J3 { get; set; }
        public string J4 { get; set; }
        public string J5 { get; set; }
        public string Um { get; set; }
        public decimal? Importe { get; set; }
    }
}
