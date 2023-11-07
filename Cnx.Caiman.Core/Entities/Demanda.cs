using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Demanda
    {
        public int IdDemanda { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int IPrioridad1 { get; set; }
        public int IPrioridad2 { get; set; }
        public int IPrioridad3 { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NDemandaManiana { get; set; }
        public decimal NDemandaTarde { get; set; }
        public decimal NDemandaNoche { get; set; }
        public decimal NDemandaTotal { get; set; }
        public string Vc8000Granel { get; set; }
        public decimal NCubiertoManiana { get; set; }
        public decimal NCubiertoTarde { get; set; }
        public decimal NCubiertoNoche { get; set; }
        public decimal NCubiertoTotal { get; set; }
        public decimal NPendienteManiana { get; set; }
        public decimal NPendienteTarde { get; set; }
        public decimal NPendienteNoche { get; set; }
        public decimal NPendienteTotal { get; set; }
        public string Vc255Observaciones { get; set; }
        public DateTime? DtFechaPlan { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public decimal? NDemandaAdmonInventario { get; set; }

        public Destino Destino { get; set; }
        public RelUso RelUso { get; set; }
        public Producto Producto { get; set; }

    }
}
