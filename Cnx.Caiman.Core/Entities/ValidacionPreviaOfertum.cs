using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ValidacionPreviaOfertum
    {
        public int IdValidacionPrevia { get; set; }
        public int IdPlanAsignacion { get; set; }
        public decimal NOfertaMaxima { get; set; }
        public int IdProducto { get; set; }
        public decimal NDemandaTotal { get; set; }
        public int IdOrigen { get; set; }
    }
}
