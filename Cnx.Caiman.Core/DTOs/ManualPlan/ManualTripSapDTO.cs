using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class ManualTripSapDto
    {
        public long IdPlanManual { get; set; }
        public string Pedido { get; set; }
        public string Linea { get; set; }
        public string Destino { get; set; }
        public string Producto { get; set; }
        public string Origen { get; set; }
        public string Cedis { get; set; }
        public string Transportista { get; set; }
        public decimal? Volumen { get; set; }
        public string Unidad { get; set; }
        public DateTime? FechaCompromiso { get; set; }
        public bool Procesado { get; set; }
        public int IdZona { get; set; }
        public string PagaFlete { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vehiculo { get; set; }
        public string nameFile { get; set; }
    }
}
