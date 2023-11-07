using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Feasibility
{
    public class OwnLinkDto
    {
        public string Transportista { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Tarifa { get; set; }
        public int Validacion { get; set; }
    }
}
