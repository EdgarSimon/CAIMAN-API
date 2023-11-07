using System;

namespace Cnx.Caiman.Core.DTOs.Origin
{
    public class OriginDto
    {
        public int IdOrigen { get; set; }
        public int IdZona { get; set; }
        public string Vc50Nombre { get; set; }
        public bool BPropio { get; set; }
        public bool BCargaAut { get; set; }
        public int IManiana { get; set; }
        public int ITarde { get; set; }
        public int INoche { get; set; }
        public int IDespachoHora { get; set; }
        public bool BServirPrioridad { get; set; }
        public string Vc10ClaveSicadi { get; set; }
        public int? IClaveSiclo { get; set; }
        public int? IClaveSit { get; set; }
        public int? IdOrigenCopia { get; set; }
        public bool BMensual { get; set; }
        public bool BMensualEntra { get; set; }
        public bool BActivo { get; set; }
        public int IdZonaHoraria { get; set; }
        public DateTime? DtPlanMensual { get; set; }
        public string VcIdAgr { get; set; }
        public string VcTipoOperacion { get; set; }
        public string VcIdVo { get; set; }
        public string VcIdOrg { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public string VcSap { get; set; }
        public string SAP { get; set; }
        public string Cedis { get; set; }
        public bool? BEsLab { get; set; }
        public string Vc25NombreCorto { get; set; }

        public OriginLocationDto OrigenUbicacion { get; set; }
        public CediDto Cedi { get; set; }
    }
}