using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class OrigenGeneral
    {
        public int IdOrigen { get; set; }
        public string Vc50Nombre { get; set; }
        public string VcSap { get; set; }
        public bool BPropio { get; set; }
        public bool BActivo { get; set; }
        public int? ZonaEntrega { get; set; }
        public string UsuarioCreo { get; set; }
        public DateTime Creado { get; set; }
        public string UsuarioModifico { get; set; }
        public DateTime Modificado { get; set; }
        public int Medicion { get; set; }
        public bool? BEsLab { get; set; }
        public Medicion _Medicion { get; set; }    
    }
}
