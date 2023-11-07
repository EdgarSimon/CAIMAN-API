using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ContratoInterfazLog
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
        public decimal? MinCosto { get; set; }
        public int? CostosDistintos { get; set; }
        public string IdTipo { get; set; }
        public string TipoDesc { get; set; }
        public string IdProd55 { get; set; }
        public DateTime DtFecha { get; set; }
        public string MinUm { get; set; }
    }
}
