using System;

namespace Cnx.Caiman.Core.DTOs.Origin
{
    public class OriginInsertDto
    {
        public string Nombre { get; set; }
        public int Zona { get; set; }
        public int Propio { get; set; }
        public int Manana { get; set; }
        public int Tarde { get; set; }
        public int Noche { get; set; }
        public int Servirprioridad { get; set; }
        public string ClaveSicadi { get; set; }
        public int ClaveSit { get; set; }
        public int Cargaaut { get; set; }
        public string Vc20usuario { get; set; }
        public string PrmIdSAP { get; set; }
        public string Vc4Cedis {get;set;}
        public string Vc25NombreCorto {get;set;}
        public DateTime? Dtfecha {get;set;}
    }
}

