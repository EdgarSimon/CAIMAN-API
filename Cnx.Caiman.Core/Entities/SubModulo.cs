using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class SubModulo
    {
        public int IdSubModulo { get; set; }
        public int IdModulo { get; set; }
        public string Vc100NombreSubModulo { get; set; }
        public string Vc255NombrePagina { get; set; }
        public bool BEsVisible { get; set; }
        public bool BEsGrafico { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public bool Hijos { get; set; }
        public virtual Modulo IdModuloNavigation { get; set; }
    }
}
