using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Feasibility
{
    public class TravelRequestsDto
    {
        public string Transportista { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Producto { get; set; }
        public int Viajes { get; set; }
        public int Pedidos_viaje { get; set; }
        public int Dif { get; set; }
        public int Validacion { get; set; }
    }
}
