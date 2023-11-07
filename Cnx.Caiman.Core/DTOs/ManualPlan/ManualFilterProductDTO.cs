using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class ManualFilterProductDTO: IEquatable<ManualFilterProductDTO>
    {
        public int id { get; set; }
        public string Description { get; set; }

        public List<ManualFilterOriginDTO> origin { get; set; }

        public bool Equals(ManualFilterProductDTO other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return id.Equals(other.id) && Description.Equals(other.Description);
        }

        public override int GetHashCode()
        {

            int hashDescription = Description == null ? 0 : Description.GetHashCode();

            int hashid = id.GetHashCode();

            return hashDescription ^ hashid;
        }
    }
}
