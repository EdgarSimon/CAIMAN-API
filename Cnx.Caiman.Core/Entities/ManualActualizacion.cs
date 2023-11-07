using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ManualActualizacion
    {
        public int? Id { get; set; }
        public string VcModulo { get; set; }
        public string VcNombreArchivo { get; set; }
        public DateTime? DtFechaActualizacion { get; set; }
    }
}
