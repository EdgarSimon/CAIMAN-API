using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ColaboracionFechaLimite
    {
        public int IdColaboracion { get; set; }
        public int? Tipo { get; set; }
        public DateTime? Mes { get; set; }
        public DateTime? DFechaLimite { get; set; }
        public byte? BActivo { get; set; }
    }
}
