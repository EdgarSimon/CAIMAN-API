using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Concret
{
    public class DestinationConcretDto
    {
        public int IdDestino { get; set; }        
        public string Vc50Nombre { get; set; }
        public int IManiana { get; set; }
        public int ITarde { get; set; }
        public int INoche { get; set; }
        public bool? BAutoAbasto { get; set; }
    }
}
