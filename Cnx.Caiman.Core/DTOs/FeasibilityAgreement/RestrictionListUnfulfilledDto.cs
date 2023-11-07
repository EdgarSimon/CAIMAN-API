using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.FeasibilityAgreement
{
    public class RestrictionListUnfulfilledDto
    {
        public int idrestriccion { get; set; }
        public string Clave { get; set; }
        public string Convenio { get; set; }
        public int cantViajesS { get; set; }
        public int cantViajesSP { get; set; }
        public int porcentaje { get; set; }
        public int correcto { get; set; }
        public int isirvea { get; set; }
        public int nmin { get; set; }
        public int nmax { get; set; }
        public int ncantidadmin { get; set; }
        public int ncantidadmax { get; set; }
        public string vcoperador { get; set; }
        public DateTime dtActualizacion { get; set; }
        public string vc20UsuarioActualizacion { get; set; }
    }
}
