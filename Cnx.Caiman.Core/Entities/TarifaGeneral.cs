using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TarifaGeneral
    {
        public string IdOrigenSap { get; set; }
        public string IdDestinoSap { get; set; }
        public string IdTransportistaSap { get; set; }
        public string Entrega { get; set; }
        public double? Distancia { get; set; }
        public string UnidadMedidaDist { get; set; }
        public decimal? ValorNeto { get; set; }
        public decimal? CantidadEntrega { get; set; }
        public string UnMedidaVenta { get; set; }
        public string CanteraExterna { get; set; }
        public string VcUsuarioCreacion { get; set; }
        public DateTime DtCreacion { get; set; }
        public string VcUsuarioActualizacion { get; set; }
        public DateTime DtActualizacion { get; set; }
    }
}
