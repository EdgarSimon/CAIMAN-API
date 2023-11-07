using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class AceptTripListDto
    {
        public int infactibles { get; set; }
        public int conveniosInf { get; set; }
        public bool bCambio { get; set; }
        public bool bAceptacion { get; set; }
        public bool copia { get; set; }
        public bool planAceptado { get; set; }
        public int ArchivoEnviado { get; set; }
        public int EstatusAzure { get; set; }
    }
}
