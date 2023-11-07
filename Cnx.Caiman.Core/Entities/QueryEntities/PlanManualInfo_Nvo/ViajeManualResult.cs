using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.Entities.QueryEntities.PlanManualInfo_Nvo
{
    public class ViajeManualResult
    {

        public long Folio { get; set; }
        public long IdPlanManual { get; set; }
        public int IdZona { get; set; }
        public int IdOrigen { get; set; }
        public string Origen { get; set; }
        public int IdDestino { get; set; }
        public string Destino { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int IdTransportista { get; set; }
        public string Transportista { get; set; }
        public int IdSubZona { get; set; }
        public string SubZona { get; set; }
        public int IdTipoProducto { get; set; }
        public string Prioridad { get; set; }
        public decimal nVolumen { get; set; }
        public int nViajes { get; set; }
        public DateTime dtFecha { get; set; }
        public long IdViaje { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime dtActualizacion { get; set; }
    }
}
