using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class DemandaPronostico
    {
        public int IdDemandaPronostico { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NDemandaPronosticada { get; set; }
        public decimal NDemandaColaborada { get; set; }
        public decimal NVenta { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public int? IPrioridad1 { get; set; }
        public int? IPrioridad2 { get; set; }
        public int? IPrioridad3 { get; set; }
    }
}
