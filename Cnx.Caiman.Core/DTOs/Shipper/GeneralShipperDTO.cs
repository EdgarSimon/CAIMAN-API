using System;
using System.Collections.Generic;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.DTOs
{
    public class GeneralShipperDto
    {
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
        public IEnumerable<Transportista> TransportistaLotes {get;set;}
    }
}