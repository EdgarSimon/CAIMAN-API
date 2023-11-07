using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Enlace
    {
        public int IdEnlace { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public decimal? NDistancia { get; set; }
        public decimal? NTarifa { get; set; }
        public decimal? NDistanciaHoras { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public int BInterfaz { get; set; }
    }
}
