using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class UpdateTripDto
    {
        public int idviaje { get; set; }
        public int prioridad { get; set; }
        public int idtransportista { get; set; }
        public int idorigen { get; set; }
        public string Vc20Usuario { get; set; }
        public int bValidar { get; set; }
    }
}
