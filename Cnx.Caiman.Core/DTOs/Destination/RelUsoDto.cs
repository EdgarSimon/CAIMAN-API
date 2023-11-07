using System;
using System.Collections.Generic;
using System.Text;
using Cnx.Caiman.Core.DTOs.Product;

namespace Cnx.Caiman.Core.DTOs.Destination
{
    public class RelUsoDto
    {
        public int IdUso { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public string CClasificacion { get; set; }
        public bool BVenta { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public decimal NPorcMeta { get; set; }
        public bool BAutoAbasto { get; set; }
        public decimal NCapacidadMinima { get; set; }
        public decimal NCapacidadMaxima { get; set; }
        public decimal NCapacidadMinimaColaborada { get; set; }
        public decimal NCapacidadMaximaColaborada { get; set; }
        public DateTime DtActCapacidadMaxima { get; set; }
        public int IInventarioMultiplo { get; set; }
        public decimal NOfertaEntrega { get; set; }
        public bool BDemanda { get; set; }
        public DestinationDto Destino { get; set; }
        public ProductDto Producto { get; set; }
    }
}
