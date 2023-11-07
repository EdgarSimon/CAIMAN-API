using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Entities.QueryEntities.TripsPlan
{
    public class TripsPlanAssigment
    {
        public string AssignmentPlanID
        { 
            get; 
            set; 
        }
        //public string payFreight
        //{
        //    get { return "4"; }
        //}

        public string planType
        {
            get;
            set;
        }

        public List<ViajeSap> details
        {
            get;
            set;
        }
    }
}
