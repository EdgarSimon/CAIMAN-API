﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Predicado
    {
        public int Restriccion { get; set; }
        public string Predicado1 { get; set; }
        public string Transportista { get; set; }
        public string Producto { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Horario { get; set; }
    }
}
