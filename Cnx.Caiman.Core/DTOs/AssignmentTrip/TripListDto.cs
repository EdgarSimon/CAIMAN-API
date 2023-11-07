using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class TripListDto
    {
        public long idviaje { get; set; }
        public long Folio { get; set; }
        public string vcTransportista { get; set; }
        public string vcOrigen { get; set; }
        public string vcDestino { get; set; }
        public string vcProducto { get; set; }
        public string vcPrioridad { get; set; }
        public string vccp { get; set; }
        public string vccd { get; set; }
        public string vcci { get; set; }
        public string vcsubzona { get; set; }
        public string vctipoproducto { get; set; }
        public int correcto { get; set; }
        public string vcdistancia { get; set; }
        public DateTime dtActualizacion { get; set; }
        public string vc20UsuarioActualizacion { get; set; }
    }
}
