using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Distance
{
    public class TariffDestinationProductDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string producto { get; set; }
        public float Distancia_F { get; set; }
        public float Tarifa_F { get; set; }
        public DateTime dtActualizacion { get; set; }
        public string vc20UsuarioActualizacion { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public Nullable<float> Tarifa_M { get; set; }
        public Nullable<float> Tarifa_P { get; set; }
        public Nullable<float> Tarifa_ED { get; set; }
        public Nullable<float> Tarifa_J { get; set; }
        public Nullable<int> UM_M { get; set; }
        public Nullable<int> UM_P { get; set; }
        public Nullable<int> UM_ED { get; set; }
        public Nullable<int> UM_J { get; set; }
        public Nullable<int> idEnlaceManual { get; set; }
        public bool EnProceso { get; set; }
        public Nullable<float> nDistancia { get; set; }
    }
}
