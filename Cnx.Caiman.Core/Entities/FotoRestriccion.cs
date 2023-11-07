using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoRestriccion
    {
        public long IdFotoRestriccion { get; set; }
        public int IdFotoRestriccionIndex { get; set; }
        public int IdRestriccion { get; set; }
        public int IdZona { get; set; }
        public string Vc20Clave { get; set; }
        public string Vc255Descripcion { get; set; }
        public int IdPerfil { get; set; }
        public int IdTransportista { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int ISirveA { get; set; }
        public int IHorario { get; set; }
        public int NMin { get; set; }
        public int NMax { get; set; }
        public int NCantidadMin { get; set; }
        public int NCantidadMax { get; set; }
        public bool BActiva { get; set; }
        public string Vc100Predicado { get; set; }
        public string Vc20PivotePronunciacion { get; set; }
        public int? IApuntador { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
    }
}
