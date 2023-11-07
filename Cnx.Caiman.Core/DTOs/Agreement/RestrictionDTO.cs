﻿using System;

namespace Cnx.Caiman.Core.DTOs.Agreement
{
    public class RestrictionDto
    {
        public int IdRestriccion { get; set; }
        public int IdZona { get; set; }
        public string Vc10Operador { get; set; }
        public int IdTransportista2 { get; set; }
        public int IdOrigen2 { get; set; }
        public int IdDestino2 { get; set; }
        public int IdProducto2 { get; set; }
        public int IHorario2 { get; set; }
        public bool BActiva { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
