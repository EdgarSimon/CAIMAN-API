using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class DestinoInterfaz
    {
        public string VcSap { get; set; }
        public string Vc50Nombre { get; set; }
        public string VcZonaEnt { get; set; }
        public bool BEsCliente { get; set; }
        public int IdZonaCaiman { get; set; }
        public string VcBorrar { get; set; }
        public string Cedis { get; set; }
        public bool BProcesado { get; set; }
        public int ISector { get; set; }
        public int IAux { get; set; }
    }
}
