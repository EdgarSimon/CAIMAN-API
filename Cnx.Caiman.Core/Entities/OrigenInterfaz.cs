using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class OrigenInterfaz
    {
        public string VcSap { get; set; }
        public string Vc50Nombre { get; set; }
        public string VcBorrar { get; set; }
        public bool BProcesado { get; set; }
        public int IAux { get; set; }
    }
}
