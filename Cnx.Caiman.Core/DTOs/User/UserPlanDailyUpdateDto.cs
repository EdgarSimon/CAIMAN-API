using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class UserPlanDailyUpdateDto
    {
        public int IdUser { get; set; }
        public int IdZone { get; set; }
        public int IdConcrete { get; set; }
        public int IdClient { get; set; }
        public int Aggregate { get; set; }
        public int Shipper { get; set; }
        public int AgreementPermit { get; set; }
        public int RulePermit { get; set; }
    }
}
