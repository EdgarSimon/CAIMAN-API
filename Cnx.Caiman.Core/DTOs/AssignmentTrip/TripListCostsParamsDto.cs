using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class TripListCostsParamsDto
    {
        public int origen { get; set; }
        public int destino { get; set; }                                                          
        public int transportista { get; set; }
        public int producto { get; set; }
        public int resultado { get; set; }
        public int iCostoPropio { get; set; }
        public int iTarifaPropia { get; set; }
        public int tipoproducto { get; set; }
        public int idsubzona { get; set; }
        public int horario { get; set; }
    }
}
