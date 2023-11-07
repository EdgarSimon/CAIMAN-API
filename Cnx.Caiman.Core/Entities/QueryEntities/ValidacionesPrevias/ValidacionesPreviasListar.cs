using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.Entities.QueryEntities.ValidacionesPrevias
{
    public class ValidacionesPreviasListar
    {
        public decimal OfertaMaxima { get; set; }
        public string vcProducto { get; set; }
        public decimal DemandaTotal { get; set; }
        public string vcOferentes { get; set; } //No estoy seguro que deba funcionar igual
        public string vcDestino { get; set; }
        public int CapacidadRecepcion { get; set; }
        public string vcTransportista { get; set; }
        public float Oferta { get; set; }
        public int CapacidadDespacho { get; set; }
        public string vcOrigen { get; set; }

    }
}
