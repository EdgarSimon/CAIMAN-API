using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RutasPaso
    {
        public string Ruta { get; set; }
        public string DescRuta { get; set; }
        public string Umventa { get; set; }
        public decimal? Importe { get; set; }
        public string NodosSal2 { get; set; }
    }
}
