using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoRelProduccion
    {
        public long IdFotoRelProduccion { get; set; }
        public int IdFotoRelProduccionIndex { get; set; }
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
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
        public int? IdDestino { get; set; }
    }
}
