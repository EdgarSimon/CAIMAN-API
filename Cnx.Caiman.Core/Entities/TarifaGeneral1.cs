using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TarifaGeneral1
    {
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int? IdZona { get; set; }
        public string IOrg { get; set; }
        public string IDst { get; set; }
        public string Cedis { get; set; }
        public string IProdM { get; set; }
        public decimal? TarifaM { get; set; }
        public decimal? DistanciaM { get; set; }
        public int? UmM { get; set; }
        public decimal? PvM { get; set; }
        public string IProdP { get; set; }
        public decimal? TarifaP { get; set; }
        public int? UmP { get; set; }
        public decimal? PvP { get; set; }
        public string IProdEd { get; set; }
        public decimal? TarifaEd { get; set; }
        public int? UmEd { get; set; }
        public decimal? PvEd { get; set; }
        public string IProdJ { get; set; }
        public decimal? TarifaJ { get; set; }
        public int? UmJ { get; set; }
        public decimal? PvJ { get; set; }
        public int? IAuxJ { get; set; }
        public int? TipoTar { get; set; }
        public string IProdF { get; set; }
        public decimal? TarifaF { get; set; }
        public decimal? DistanciaF { get; set; }
        public int? UmF { get; set; }
        public decimal? PvF { get; set; }
        public DateTime? DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
