using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ArchivosInterfazSap
    {
        public string Entidad { get; set; }
        public string Archivo { get; set; }
        public bool Procesado { get; set; }
        public DateTime Creacion { get; set; }
    }
}
