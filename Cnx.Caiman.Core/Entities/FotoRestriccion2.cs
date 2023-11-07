using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoRestriccion2
    {
        public int IdFotoRestriccion2 { get; set; }
        public int IdFotoRestriccionIndex { get; set; }
        public int IdRestriccion { get; set; }
        public int IdZona { get; set; }
        public string Vc10Operador { get; set; }
        public int IdTransportista2 { get; set; }
        public int IdOrigen2 { get; set; }
        public int IdDestino2 { get; set; }
        public int IdProducto2 { get; set; }
        public int IHorario2 { get; set; }
        public bool BActiva { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
    }
}
