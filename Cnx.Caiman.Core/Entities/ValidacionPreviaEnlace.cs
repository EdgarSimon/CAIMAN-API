using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ValidacionPreviaEnlace
    {
        public int IdValidacionPrevia { get; set; }
        public int IdPlanAsignacion { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int ICantidad { get; set; }
    }
}
