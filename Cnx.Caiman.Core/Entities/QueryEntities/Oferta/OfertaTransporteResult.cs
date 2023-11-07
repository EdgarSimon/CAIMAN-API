using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Entities.QueryEntities.Oferta
{
    public class OfertaTransporteResult
    {
        public int IdOfertaTransporte { get; set; }
        
        public int Maneja { get; set; }
        public string Transportista { get; set; }
        public string Viajes { get; set; }
        public string Oferta { get; set; }
        public float Asignado { get; set; }
        public float Disponible { get; set; }
        public string Observaciones { get; set; }
        public int IdTransportista { get; set; }
        public DateTime? DtFecha { get; set; }
        
    }
}
