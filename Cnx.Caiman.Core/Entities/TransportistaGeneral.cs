using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public class TransportistaGeneral
    {
        public TransportistaGeneral()
        {
            this.TransportistaLotes = new List<Transportista>();
        }
        public int IdTransportista { get; set; }
        public string VcSap { get; set; }
        public string Vc50Nombre { get; set; }
        public bool? BActivo { get; set; }
        public bool? BPropio { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public bool BEsProveedor { get; set; }
        public string Vc25NombreCorto { get; set; }
        public List<Transportista> TransportistaLotes {get;set;}
    }
}
