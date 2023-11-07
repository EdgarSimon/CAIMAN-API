using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Entities
{
    public class Script
    {
        public Script()
        {
            this.Params = new List<ScriptsParams>();
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
        public List<ScriptsParams> Params { get; set; }
    }
}
