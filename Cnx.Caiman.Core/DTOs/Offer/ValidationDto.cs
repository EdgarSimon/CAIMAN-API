using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Offer
{
    public class ValidationDto
    {
        public bool Photo { get; set; }
        public bool Camera { get; set; }
        public bool CreatePhoto { get; set; }
        public List<string> PhotoMensaje { get; set; }
    }
}
