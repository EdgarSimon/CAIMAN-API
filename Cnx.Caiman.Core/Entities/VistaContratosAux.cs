using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class VistaContratosAux
    {
        public string IdContrato { get; set; }
        public string VcSapOrigen { get; set; }
        public string Vc50Nombre { get; set; }
        public string VcSapProducto { get; set; }
        public string VcNombre55 { get; set; }
        public decimal? NPrecio { get; set; }
        public string UnidadMedida { get; set; }
        public string Cedis { get; set; }
        public string VcDescripcion { get; set; }
        public DateTime? PlazoLicitacion { get; set; }
        public string PagaFlete { get; set; }
        public string Ruta { get; set; }
        public string Tipo { get; set; }
    }
}
