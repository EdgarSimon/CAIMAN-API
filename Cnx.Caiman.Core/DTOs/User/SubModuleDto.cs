using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class SubModuleDto
    {
        public int IdModule { get; set; }
        public int IdSubModule { get; set; }
        public string Name { get; set; }
        public bool Childs { get; set; }
        public List<PageDto> Pages { get; set; }
    }
}
