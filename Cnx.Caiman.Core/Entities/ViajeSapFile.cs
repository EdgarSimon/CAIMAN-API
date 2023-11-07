using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Entities
{
    public partial class ViajeSapFile
    {
        public string Pedido { get; set; }
        public int? Linea { get; set; }
        public string Destino { get; set; }
        public string Producto { get; set; }
        public string Origen { get; set; }
        public string Cedis { get; set; }
        public string Transportista { get; set; }
        public decimal? Volumen { get; set; }
        public string Unidad { get; set; }
        public DateTime? FechaCompromiso { get; set; }
        public bool? Procesado { get; set; }
        public int? IdZona { get; set; }
        public string PagaFlete { get; set; }
        public string Vehiculo { get; set; }
        public DateTime DtCreacion { get; set; }
    }
}
