using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class CuboCaimanReal
    {
        public int IdZona { get; set; }
        public string Zona { get; set; }
        public string TipoDestino { get; set; }
        public int IdDestino { get; set; }
        public string Vc12ClaveSap { get; set; }
        public string Destino { get; set; }
        public int IdProducto { get; set; }
        public string Prod55 { get; set; }
        public string Producto { get; set; }
        public int IdOrigen { get; set; }
        public string VcSap { get; set; }
        public string Origen { get; set; }
        public decimal? Costo { get; set; }
        public decimal? PesoVol { get; set; }
        public decimal? Tarifa { get; set; }
        public decimal? Distancia { get; set; }
        public decimal? Flete { get; set; }
        public int? IdProduccion { get; set; }
        public int? IdEnlace { get; set; }
        public string ZonaSap { get; set; }
        public decimal? Calidad { get; set; }
        public decimal? Integral { get; set; }
        public DateTime? DtFecha { get; set; }
        public int? TipoTarifa { get; set; }
        public DateTime? DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public decimal? CostoOp { get; set; }
        public decimal? FleteOp { get; set; }
        public string VcSapProducto { get; set; }
        public string Cedis { get; set; }
        public int? TipoTarifaAux { get; set; }
    }
}
