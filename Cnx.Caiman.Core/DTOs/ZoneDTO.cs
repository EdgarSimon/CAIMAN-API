using System;

namespace Cnx.Caiman.Core.DTOs
{
    public class ZoneDto
    {
        public int IdZona { get; set; }
        public string Vc50Nombre { get; set; }
        public decimal NUnidadesPorViaje { get; set; }
        public int IdMedicion { get; set; }
        public int IInventario { get; set; }
        public int IOfertaTransporte { get; set; }
        public int IOferta { get; set; }
        public int IDemanda { get; set; }
        public int IDifZonaHoraria { get; set; }
        public bool BManejaTiempos { get; set; }
        public bool BTarifaUnica { get; set; }
        public bool BHerenciaOfertaTransporte { get; set; }
        public bool BHerenciaOferta { get; set; }
        public bool BHerenciaDemanda { get; set; }
        public bool BCatInfoAdicional { get; set; }
        public bool BGranel { get; set; }
        public bool BSit { get; set; }
        public bool BActiva { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public int ITipoDealer { get; set; }
        public bool BOptimizadorFull { get; set; }
        public bool BOferta2 { get; set; }
        public int IdTipoZona { get; set; }
        public MeasurementDto Medicion { get; set; }

    }
}
