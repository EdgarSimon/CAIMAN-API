﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TipoProducto
    {
        public int IdTipoProducto { get; set; }
        public string Vc20TipoProducto { get; set; }
        public int IdCadena { get; set; }
        public int IdZona { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
