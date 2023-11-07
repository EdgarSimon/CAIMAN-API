using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RutasInterfaz
    {
        public int IAux { get; set; }
        public string IOrg { get; set; }
        public string IDst { get; set; }
        public string Material { get; set; }
        public string Ruta { get; set; }
        public string Um { get; set; }
        public decimal? Importe { get; set; }
        public string Cedis { get; set; }
    }
}
