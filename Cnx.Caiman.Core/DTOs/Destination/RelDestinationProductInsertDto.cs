using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Destination
{
    public class RelDestinationProductInsertDto
    {
        public int IdProducto { get; set; }
        public int IdDestino { get; set; }
        public int IPorcMeta { get; set; }
        public bool BAutoAbasto { get; set; }
        public float NCapacidadMaxima { get; set; }
        public float NCapacidadMinima { get; set; }
        public int IInventarioMultiplo { get; set; }
        public bool Venta { get; set; }
        public string Vc20usuario { get; set; }
        public float NOfertaEntrega { get; set; }
        public bool BDemanda { get; set; }        
    }
}
