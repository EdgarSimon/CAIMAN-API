using System;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.DTOs.Product;

namespace Cnx.Caiman.Core.DTOs.Distance
{
    public class RelProductionDto
    {
        public int IdProduccion { get; set; }
        public int IdOrigen { get; set; }
        public int IdProducto { get; set; }
        public decimal NCostoIntegral { get; set; }
        public decimal NCostoPorCalidad { get; set; }
        public decimal NPrecio { get; set; }
        public decimal NPesoVolumetrico { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public string VcSapproducto { get; set; }
        public string VcNombre900 { get; set; }
        public string VcContrato { get; set; }
        public decimal? Kilogramos { get; set; }
        public int? IdTipoSc { get; set; }
        public decimal? CostoCemento { get; set; }
        public decimal? NFactorUso { get; set; }

        public ProductDto Producto { get; set; }
        public OriginDto Origen { get; set; }
    }
}
