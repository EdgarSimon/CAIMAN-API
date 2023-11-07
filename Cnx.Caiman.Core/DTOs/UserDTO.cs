using System;

namespace Cnx.Caiman.Core.DTOs
{
    public class UserDto
    {
        public int IdUsuario { get; set; }
        public int IdUserUpdate { get; set; }
        public int IdZona { get; set; }
        public byte TiEstatus { get; set; }
        public int IdIdioma { get; set; }
        public int IDia { get; set; }
        public string Dia
        {
            get
            {
                var returnValue = "Hoy";
                if(IDia == 1)
                {
                    returnValue = "Mañana";
                }

                return returnValue;
            }            
        }
        public string Vc20ClaveUsuario { get; set; }
        public string Vc80NombreUsuario { get; set; }
        public string Vc20UsuarioAds { get; set; }
        public string Vc50Correo { get; set; }
        public bool BAdministrador { get; set; }
        public bool BMensual { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public bool? BAccesoLupa { get; set; }
        public string Vc50Contrasena { get; set; }
    }
}
