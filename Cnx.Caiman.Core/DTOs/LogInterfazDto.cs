using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs
{
    public class LogInterfazDto
    {
        public long IdLogInterfaz { get; set; }
        public string Tabla { get; set; }
        public DateTime Fecha { get; set; }
        public bool Procesado { get; set; }
        public string Archivo { get; set; }
    }
}
