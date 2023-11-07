using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.Agreement
{
    public class AgreementSaveDto
    {
        public int IdRestriccion { get; set; }
        public string vcClave { get; set; }
        public string vcDescripcion { get; set; }
        public int IdTransportista { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int IdHorario { get; set; }
        public int IdTransportista2 { get; set; }
        public int IdOrigen2 { get; set; }

        public int IdDestino2 { get; set; }
        public int IdProducto2 { get; set; }
        public int IdHorario2 { get; set; }

        public int iMin { get; set; }
        public int iMax { get; set; }

        public Int64 TID { get; set; }

        public int idZona { get; set; }
        public int iCantidadMin { get; set; }
        public int iCantidadMax { get; set; }
        public int iPor1 { get; set; }

        public int iPor2 { get; set; }

        public int bSirveA { get; set; }

        public string EntidadAbsoluta { get; set; }

        public string EntidadSecundaria { get; set; }
        public string Traduccion { get; set; }
        
        [JsonIgnore]
        public string vc20Usuario { get; set; }
        public string operador { get; set; }

        public int IdPerfil { get; set; }
        public int idfrecuencia { get; set; }
    }
}
