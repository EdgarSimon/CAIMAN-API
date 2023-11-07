﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.DTOs.ProductInterface
{
    public class ProductInterfaceExceptionDto
    {
        public string VcSap { get; set; }
        public string IdProd55 { get; set; }
        public string VcNombre55 { get; set; }
        public decimal? NPesoVolumetrico { get; set; }
        public DateTime? DtCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
