using System;
using System.Collections.Generic;

namespace Cnx.Caiman.Core.DTOs.Agreement
{
    public class AgreementDailyPlanDto
    {
        public int idzone { get; set; }
        public string idagreement { get; set; }
        public DateTime date { get; set; }
        public bool select { get; set; }
        public int iduser { get; set; }
        public bool applyAll { get; set; }
        public string agreementexclude  { get; set; }
    }
}
