using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class ListEditTripDto
    {
        public int idviaje { get; set; }
        public int Folio { get; set; }
        public string vcTransportista { get; set; }
        public int IdTransportista { get; set; }
        public string vcOrigen { get; set; }
        public int IdOrigen { get; set; }
        public string vcDestino { get; set; }
        public string vcProducto { get; set; }
        public int Prioridad { get; set; }
        public string vcsubzona { get; set; }
        public string vctipoproducto { get; set; }
        public DateTime dtActualizacion { get; set; }
        public string vc20UsuarioActualizacion { get; set; }
    }
}
