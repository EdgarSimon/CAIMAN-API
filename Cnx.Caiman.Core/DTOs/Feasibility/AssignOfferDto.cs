using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Feasibility
{
    public class AssignOfferDto
    {
        public string Origen { get; set; }
        public string Producto { get; set; }
        public int Oferta_Total { get; set; }
        public int Cantidad_Asignada { get; set; }
        public int Validacion { get; set; }
    }
}
