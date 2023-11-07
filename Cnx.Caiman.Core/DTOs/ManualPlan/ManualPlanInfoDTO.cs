using System;
using System.Collections.Generic;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class ManualPlanInfoDto
    {
        private string _vc20Autorizacion;

        public long IdPlanManual { get; set; }
        public int IdZona { get; set; }
        public string vc50Nombre { get; set; }
        public DateTime dtFecha { get; set; }
        public int bAceptacion { get; set; }
        public DateTime dtCreacion { get; set; }
        public DateTime dtActualizacion { get; set; }
        public string vc20UsuarioCreacion { get; set; }
        public string vc20UsuarioActualizacion { get; set; }
        public DateTime dtAutorizacion { get; set; }
        public string vc20Autorizacion
        {
            get
            {
                return _vc20Autorizacion;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _vc20Autorizacion = "";
                else
                    _vc20Autorizacion = value;
            }
        }
        public float viajesEnPlan { get; set; }
        public float avgViajes { get; set; }
        public float viajesManualesAceptados { get; set; }
        public float viajesManualesActual { get; set; }
        public string mensaje { get; set; }
        public int archivoEnviado { get; set; }
        public int EstatusAzure { get; set; }
        public List<ManualPlanTripDto> planManualDetalle { get; set; }
    }
}
