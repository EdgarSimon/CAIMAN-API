using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Transportista
    {
        public int IdTransportista { get; set; }
        public int IdZona { get; set; }
        public string Vc50Nombre { get; set; }
        public decimal NTarifa { get; set; }
        public int ICantSencillos { get; set; }
        public decimal NCantidadPorViaje { get; set; }
        public int IManiana { get; set; }
        public int ITarde { get; set; }
        public int INoche { get; set; }
        public int IManeja { get; set; }
        public int? IClaveSit { get; set; }
        public bool BPropio { get; set; }
        public bool BTarifaPropia { get; set; }
        public bool BServirPrioridad { get; set; }
        public int? IdTransportistaCopia { get; set; }
        public bool BMensual { get; set; }
        public bool BMensualEntra { get; set; }
        public bool BActivo { get; set; }
        public DateTime? DtPlanMensual { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public string VcSap { get; set; }
        public int? IdTipoLote { get; set; }
        public int? IdTranspGeneral { get; set; }
        public string Vc25NombreCorto { get; set; }
    }
}
