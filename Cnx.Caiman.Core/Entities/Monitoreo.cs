using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Monitoreo
    {
        public int IdMonitoreo { get; set; }
        public long IdViaje { get; set; }
        public int IdResultado { get; set; }
        public int IdPlanAsignacion { get; set; }
        public int IdZona { get; set; }
        public string Vc20Remision { get; set; }
        public string VcViajeAgrupado { get; set; }
        public int NFolioViaje { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int IdTransportista { get; set; }
        public string Vc10Placas { get; set; }
        public int? ITonelajeAg { get; set; }
        public int? ITonelajeCc { get; set; }
        public DateTime DtFecha { get; set; }
        public int IPrioridad { get; set; }
        public int NCantidadAsignada { get; set; }
        public decimal NCantidadReal { get; set; }
        public int IEstatus { get; set; }
        public int ICorrecto { get; set; }
        public int BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public int IdObservacion { get; set; }
        public bool BLlegoOrigen { get; set; }
        public string Vc20UsuarioLlegoOrigen { get; set; }
        public DateTime DtLlegoOrigen { get; set; }
        public bool BCargo { get; set; }
        public string Vc20UsuarioCargo { get; set; }
        public DateTime DtCargo { get; set; }
        public bool BLlegoDestino { get; set; }
        public string Vc20UsuarioLlegoDestino { get; set; }
        public DateTime DtLlegoDestino { get; set; }
        public bool BCerroDestino { get; set; }
        public string Vc20UsuarioCerroDestino { get; set; }
        public DateTime DtCerroDestino { get; set; }
        public bool BCerroTransportista { get; set; }
        public string Vc20UsuarioCerroTransportista { get; set; }
        public DateTime DtCerroTransportista { get; set; }
        public bool BCancelado { get; set; }
        public string Vc20UsuarioCancelado { get; set; }
        public DateTime DtCancelado { get; set; }
        public bool BNuevoViaje { get; set; }
        public string Vc20UsuarioNuevoViaje { get; set; }
        public DateTime DtNuevoViaje { get; set; }
        public bool BViajeDesviado { get; set; }
        public string Vc20UsuarioViajeDesviado { get; set; }
        public DateTime DtViajeDesviado { get; set; }

        public virtual Zona IdZonaNavigation { get; set; }
    }
}
