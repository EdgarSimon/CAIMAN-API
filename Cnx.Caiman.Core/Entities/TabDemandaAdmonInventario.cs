using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TabDemandaAdmonInventario
    {
        public int IdDemanda { get; set; }
        public int IdZona { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public DateTime DtFecha { get; set; }
        public int IdInventario { get; set; }
        public decimal NCapacidadMaxima { get; set; }
        public decimal NInventarioActual { get; set; }
        public decimal NConsumoDia { get; set; }
        public decimal NConsumoPromedio { get; set; }
        public decimal NDiasInventario { get; set; }
        public decimal NMeta { get; set; }
        public decimal NInventarioProximo { get; set; }
        public decimal NDemandaAsignada { get; set; }
        public int IDemandaViajes { get; set; }
        public decimal NPorcAlcanzado { get; set; }
        public decimal NDiferencia { get; set; }
        public decimal NPorcMeta { get; set; }
        public decimal NPorcActual { get; set; }
        public int IInventarioMultiplo { get; set; }
        public double FPrioridad { get; set; }
        public bool? BCandado { get; set; }
        public string VcComentario { get; set; }
        public bool BActivo { get; set; }
        public string VcComentarioUsuario { get; set; }
        public string VcUsuarioComentario { get; set; }
        public DateTime? DtFechaComentario { get; set; }
        public int? IdComentario { get; set; }

        public virtual ComentarioAi IdComentarioNavigation { get; set; }
    }
}
