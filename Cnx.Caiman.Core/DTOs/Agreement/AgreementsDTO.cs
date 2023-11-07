using System;

namespace Cnx.Caiman.Core.DTOs.Agreement
{
    public class AgreementsDto
    {
        public int IdConvenios { get; set; }
        public int IdRestriccion { get; set; }
        public int IdZona { get; set; }
        public DateTime DtFecha { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
