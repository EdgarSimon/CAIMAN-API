using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ComentarioAi
    {
        public ComentarioAi()
        {
            TabDemandaAdmonInventarios = new HashSet<TabDemandaAdmonInventario>();
        }

        public int IdComentario { get; set; }
        public string VcComentario { get; set; }
        public string VcSolucion { get; set; }

        public virtual ICollection<TabDemandaAdmonInventario> TabDemandaAdmonInventarios { get; set; }
    }
}
