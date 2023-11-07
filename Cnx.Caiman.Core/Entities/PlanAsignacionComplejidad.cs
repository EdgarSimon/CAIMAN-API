using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class PlanAsignacionComplejidad
    {
        public int? IdPlanAsignacion { get; set; }
        public string Nombre { get; set; }
        public int? Idzona { get; set; }
        public string Dtfecha { get; set; }
        public double? Complejidad { get; set; }
        public int? CantOrigenes { get; set; }
        public int? CantDestinos { get; set; }
        public int? CantProductos { get; set; }
        public int? CantTransportistas { get; set; }
        public int? CantProduccion { get; set; }
        public int? CantUso { get; set; }
        public int? CantEnlace { get; set; }
        public int? CantOdt { get; set; }
        public int? TiempoMinutos { get; set; }
        public int? IndDemanda { get; set; }
        public int? IndOferta { get; set; }
        public int? IndOfertatransporte { get; set; }
        public int? NumConvenios { get; set; }
        public int? NumRestriciones { get; set; }
        public int? NumRestriccionesDestino { get; set; }
        public int? NumRestriccionesOrigen { get; set; }
        public int? NumRestriccionesProducto { get; set; }
        public int? NumRestriccionesTransportista { get; set; }
        public int? NumRestriccionesHorario { get; set; }
        public int? NumRestriciones2 { get; set; }
        public int? CantDemandapronostico { get; set; }
        public int? CantOfertapronostico { get; set; }
        public int? CantOfertatransportepronostico { get; set; }
    }
}
