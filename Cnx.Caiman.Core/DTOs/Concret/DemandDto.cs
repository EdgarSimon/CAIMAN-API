using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Concret
{
    public class DemandDto
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
        public bool Activo
        {
            get
            {
                if ((this.RelUso != null && this.RelUso.BAutoAbasto) && (this.Destino != null && (bool)this.Destino.BAutoAbasto))
                    return false;
                else
                    return true;
            }
        }

        public DestinationConcretDto Destino { get; set; }
        public RelUseConcretDto RelUso { get; set; }
        public ProductConcretDto Producto { get; set; }
    }
}
