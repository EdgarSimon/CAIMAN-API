using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class DemandaPronosticoOrigen
    {
        public int IdDemandaPronostico { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int IdOrigen { get; set; }
        public int? IdTransportista { get; set; }
        public string VcSap { get; set; }

        public virtual DemandaPronostico IdDemandaPronosticoNavigation { get; set; }
    }
}
