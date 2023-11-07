using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ContratoInterfazAux
    {
        public string IdContrato { get; set; }
        public string VcSapOrigen { get; set; }
        public string VcSapProducto { get; set; }
        public decimal? NPrecio { get; set; }
        public string UnidadMedida { get; set; }
        public string Cedis { get; set; }
        public DateTime? PlazoLicitacion { get; set; }
        public string PagaFlete { get; set; }
        public string Ruta { get; set; }
    }
}
