using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoOfertum
    {
        public long IdFotoOferta { get; set; }
        public int IdFotoOfertaIndex { get; set; }
        public int IdOferta { get; set; }
        public int IdOrigen { get; set; }
        public int IdProducto { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NOfertaManiana { get; set; }
        public decimal NOfertaTarde { get; set; }
        public decimal NOfertaNoche { get; set; }
        public decimal NOfertaTotal { get; set; }
        public decimal NAsignadoManiana { get; set; }
        public decimal NAsignadoTarde { get; set; }
        public decimal NAsignadoNoche { get; set; }
        public decimal NAsignadoTotal { get; set; }
        public decimal NDisponibleManiana { get; set; }
        public decimal NDisponibleTarde { get; set; }
        public decimal NDisponibleNoche { get; set; }
        public decimal NDisponibleTotal { get; set; }
        public string Vc255Observaciones { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
    }
}
