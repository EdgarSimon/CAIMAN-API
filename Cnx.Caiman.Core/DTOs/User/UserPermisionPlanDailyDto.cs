using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class UserPermisionPlanDailyDto
    {   
        public int idzona { get; set; }
        public int iduser { get; set; }
        public int module { get; set; }
        public List<UserchekUpdateDto> Marcado { get; set; }

    }
}
