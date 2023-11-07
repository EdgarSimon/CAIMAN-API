namespace Cnx.Caiman.Core.DTOs.Destination
{
    public class DestinationInsertDto
    {
        public string Nombre { get; set; }
        public int Zona { get; set; }
        public int Manana { get; set; }
        public int Tarde { get; set; }
        public int Noche { get; set; }
        public int Idsubzona { get; set; }
        public int Clavesicadi { get; set; }
        public int ClaveSit { get; set; }
        public int AutoAbasto { get; set; }
        public int Pronostico { get; set; }
        public int Venta {get;set;}
        public string Vc20usuario {get;set;}
        public string Vc12claveSAP { get; set; }
        public string Vc4cedis { get; set; }
        public string Vc25NombreCorto { get; set; }
    }
}