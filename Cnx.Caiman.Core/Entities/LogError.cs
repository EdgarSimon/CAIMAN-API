using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class LogError
    {
        public long IdLogError { get; set; }
        public string Catalogo { get; set; }
        public string Proceso { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdZona { get; set; }
        public string Perfil { get; set; }
        public DateTime? DtFechaPlanDiario { get; set; }
    }
}
