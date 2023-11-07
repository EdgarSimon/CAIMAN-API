using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class PedidosCaiman
    {
        public string Pedido { get; set; }
        public int? Linea { get; set; }
        public DateTime? FechaCompromiso { get; set; }
        public string Destino { get; set; }
        public string Producto { get; set; }
        public decimal? Demanda { get; set; }
        public string Unidad { get; set; }
        public string Origen1 { get; set; }
        public string Origen2 { get; set; }
        public DateTime? FechaProcesado { get; set; }
        public int? IdDestino { get; set; }
        public int? IdProducto { get; set; }
        public int? IdZona { get; set; }
        public int? Viajes { get; set; }
        public DateTime? FechaCaimanizado { get; set; }
        public int? IdOrigen { get; set; }
        public string TipoPedido { get; set; }
    }
}
