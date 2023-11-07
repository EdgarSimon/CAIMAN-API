using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public decimal NCapacidadMinima { get; set; }
        public decimal NCapacidadMaxima { get; set; }
        public decimal NInventarioInicial { get; set; }
        public decimal? NInventarioInicialReal { get; set; }
        public decimal NEntradasPronostico { get; set; }
        public decimal? NEntradasReal { get; set; }
        public decimal NConsumoPronostico { get; set; }
        public decimal NVentaPronostico { get; set; }
        public decimal NSalidaPronostico { get; set; }
        public decimal NSalidaInteligente { get; set; }
        public decimal NSalidaManual { get; set; }
        public int ITipoSalidaHoy { get; set; }
        public decimal? NSalidaReal { get; set; }
        public int ICambioInventarioInicial { get; set; }
        public int ICambioSalida { get; set; }
        public int ICambioVenta { get; set; }
        public DateTime DtFecha { get; set; }
        public string Vc255Observaciones { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
