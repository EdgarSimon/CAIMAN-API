using System;
using System.Collections.Generic;

namespace Cnx.Caiman.Core.DTOs.Scripts
{
    public class ScriptDto
    {
        public ScriptDto()
        {
            this.Params = new List<ScriptsParamsDto>();
        }
        public int IdScript { get; set; }
        public string Nombre { get; set; }
        public string VcDescripcion { get; set; }
        public bool BActivo { get; set; }
        public string vcUsuarioCreo { get; set; }
        public DateTime DtCreacion { get; set; }
        public string VcUsuarioModifico { get; set; }
        public DateTime DtModificado { get; set; }
        public bool BStatus { get; set; }
        public string StatusMessage { get; set; }
        public string ReturnType { get; set; }
        public List<ScriptsParamsDto> Params { get; set; }
    }
}