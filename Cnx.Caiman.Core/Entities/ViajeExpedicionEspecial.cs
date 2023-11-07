using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ViajeExpedicionEspecial
    {
        public int IdOrigen { get; set; }
        public int IdProducto { get; set; }
        public int IdDestino { get; set; }
        public int IdTransportista { get; set; }
        public string CondExpedicion { get; set; }
    }
}
