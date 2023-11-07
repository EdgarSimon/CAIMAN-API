using Cnx.Caiman.Core.DTOs.User;
using System.Collections.Generic;

namespace Cnx.Caiman.Core.DTOs
{
    public class UserLoginResponseDto
    {
        public UserDto User { get; set; }

        public IEnumerable<ZoneDto> Zones { get; set; }

        public IEnumerable<ModuleDto> Module { get; set; }

        public string Token { get; set; }
    }
}
