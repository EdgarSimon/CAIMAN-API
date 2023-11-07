using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Viaje
    {
        public long IdViaje { get; set; }
        public int IdResultado { get; set; }
        public int IdPlanAsignacion { get; set; }
        public int IdZona { get; set; }
        public int NFolioViaje { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int IdTransportista { get; set; }
        public DateTime DtFecha { get; set; }
        public int IPrioridad { get; set; }
        public decimal NCantidadAsignada { get; set; }
        public int IEstatus { get; set; }
        public int ICorrecto { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }

        public virtual Zona IdZonaNavigation { get; set; }
    }
}
