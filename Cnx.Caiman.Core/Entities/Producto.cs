using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public int IdZona { get; set; }
        public string Vc50Nombre { get; set; }
        public int IdTipoProducto { get; set; }
        public int? IClaveSiclo { get; set; }
        public string Vc10ClaveSiclo { get; set; }
        public int? IClaveSit { get; set; }
        public int? IdProductoCopia { get; set; }
        public bool BMensual { get; set; }
        public bool BMensualEntra { get; set; }
        public bool BActivo { get; set; }
        public DateTime? DtPlanMensual { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public decimal? NFactorConversion { get; set; }
        public int? IdProd55 { get; set; }
        public string Vc25NombreCorto { get; set; }
        public TipoProducto TipoProducto {get; set; }
    }
}
