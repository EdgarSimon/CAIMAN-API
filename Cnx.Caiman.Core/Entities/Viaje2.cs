using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Viaje2
    {
        public int IdResultado { get; set; }
        public int IdPlanAsignacion { get; set; }
        public int IdZona { get; set; }
        public int NFolioViaje { get; set; }
        public int IdOrigen { get; set; }
        public string Vc50NombreOrigen { get; set; }
        public int IdDestino { get; set; }
        public string Vc50NombreDestino { get; set; }
        public int IdProducto { get; set; }
        public string Vc50NombreProducto { get; set; }
        public int IdTransportista { get; set; }
        public string Vc50NombreTransportista { get; set; }
        public DateTime DtFecha { get; set; }
        public int IPrioridad { get; set; }
        public decimal NCantidadAsignada { get; set; }
        public bool BTransaccion { get; set; }
    }
}
