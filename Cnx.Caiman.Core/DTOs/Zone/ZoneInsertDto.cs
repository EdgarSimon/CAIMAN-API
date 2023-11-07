namespace Cnx.Caiman.Core.DTOs.Zone
{
    public class ZoneInsertDto
    {

        public string Vc50Nombre { get; set; }
        public int NUnidadesPorViaje { get; set; }
        public int IdMedicion { get; set; }
        public bool BOptimizadorFull { get; set; }
        public bool BManejaTiempos { get; set; }
        public bool BTarifaUnica { get; set; }
        public bool BOferta2 { get; set; }
        public bool BGranel { get; set; }
        public bool BSit { get; set; }
        public string Vc20Usuario {get; set; }
    }
}