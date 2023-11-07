using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TarifasNoJoin
    {
        public string Destino { get; set; }
        public string Origen { get; set; }
        public int? IdOrigen { get; set; }
        public int? IdDestino { get; set; }
        public double? NDestancia { get; set; }
        public double? NTarifa { get; set; }
        public int Activo { get; set; }
        public int BInterfaz { get; set; }
    }
}
