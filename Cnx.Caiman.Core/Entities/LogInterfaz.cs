using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public class LogInterfaz
    {
        public long IdLogInterfaz { get; set; }
        public string Tabla { get; set; }
        public DateTime Fecha { get; set; }
        public bool Procesado { get; set; }
        public string Archivo { get; set; }
    }
}
