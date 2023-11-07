using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Modulo
    {
        public Modulo()
        {
            Paginas = new HashSet<Pagina>();
            SubModulos = new HashSet<SubModulo>();
        }

        public int IdModulo { get; set; }
        public string Vc100NombreModulo { get; set; }
        public bool BEsVisible { get; set; }
        public bool BEsGrafico { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }

        public virtual ICollection<Pagina> Paginas { get; set; }
        public virtual ICollection<SubModulo> SubModulos { get; set; }
    }
}
