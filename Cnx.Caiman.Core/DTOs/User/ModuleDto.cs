using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class ModuleDto
    {
        public int IdModule { get; set; }
        public string Name { get; set; }
        public List<SubModuleDto> SubModule { get; set; }
    }
}
