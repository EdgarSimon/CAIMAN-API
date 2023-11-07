using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Agreement
{
    public class FindInfoDto
    {
        public int IdTransportista { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int IdHorario { get; set; }
        public int IdTransportista2 { get; set; }
        public int IdOrigen2 { get; set; }
        public int IdDestino2 { get; set; }
        public int IdProducto2 { get; set; }
        public int IdHorario2 { get; set; }
        public long TID { get; set; }
        public int IdRestriccion { get; set; }
    }
}
