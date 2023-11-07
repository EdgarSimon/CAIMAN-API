using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public class Usuario
    {
        public int IdUsuario
        {
            get;
            set;
        }

        public int IdZona
        {
            get;
            set;
        }

        public byte TiEstatus
        {
            get;
            set;
        }

        public int IdIdioma
        {
            get;
            set;
        }

        public int IDia
        {
            get;
            set;
        }

        public string Vc20ClaveUsuario
        {
            get;
            set;
        }

        public string Vc80NombreUsuario
        {
            get;
            set;
        }

        public string Vc20UsuarioAds
        {
            get;
            set;
        }

        public string Vc50Contrasena
        {
            get;
            set;
        }

        public string Vc50Correo
        {
            get;
            set;
        }

        public bool BAdministrador
        {
            get;
            set;
        }

        public bool BMensual
        {
            get;
            set;
        }

        public bool BActivo
        {
            get;
            set;
        }

        public DateTime DtCreacion
        {
            get;
            set;
        }

        public DateTime DtActualizacion
        {
            get;
            set;
        }

        public string Vc20UsuarioCreacion
        {
            get;
            set;
        }

        public string Vc20UsuarioActualizacion
        {
            get;
            set;
        }

        public bool? BAccesoLupa
        {
            get;
            set;
        }

        public Zona Zona
        {
            get;
            set;
        }        
    }
}
