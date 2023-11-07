using System;
namespace Cnx.Caiman.Core.DTOs.Scripts
{
    public class ScriptsParamsDto
    {
        public int IdScriptParam { get; set; }
        public string Nombre { get; set; }
        public string VcDescripcion { get; set; }
        public bool BActivo { get; set; }
        public DateTime? dtCreacion { get; set; }
        public string VcUsuarioModifico { get; set; }
        public DateTime? DtModificado { get; set; }
        public string Tipo { get; set; }
        public bool EsRequerido { get; set; }
        public int IdScript { get; set; }
    }
}
