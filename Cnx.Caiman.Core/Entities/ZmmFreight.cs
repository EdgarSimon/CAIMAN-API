using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ZmmFreight
    {
        public string Ruta { get; set; }
        public string AgenteServicios { get; set; }
        public string Material { get; set; }
        public string DescripciónRuta { get; set; }
        public string MonedaCondicion { get; set; }
        public string UnidadDeMedida { get; set; }
        public string ReglaDeCalculo { get; set; }
        public string Denominacion { get; set; }
        public string Distancia { get; set; }
        public string UnidadMedDistancia { get; set; }
        public string ImporteCondicion { get; set; }
        public string CantidadBase { get; set; }
        public string InicioValidez { get; set; }
        public string FinValidez { get; set; }
        public string NodosDeSalida { get; set; }
        public string Proveedor { get; set; }
        public string DescPuntoOrigen { get; set; }
        public string NodosDeSalida2 { get; set; }
        public string DescPuntoDestino { get; set; }
    }
}
