using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.Entities.QueryEntities.Oferta
{
    public class OfertaResult
    {
        //               
        public int idOferta { get; set; }
        public string Origen { get; set; }
        public string Producto { get; set; }
        public int Oferta { get; set; }

        public int OfertaPantalla { get; set; }
        public int ORec { get; set; }
        public int ECli { get; set; }
        public int EConc { get; set; }

        public int Asignado { get; set; }
        public int Disponible { get; set; }
        public decimal Precio { get; set; }
        public string Observaciones { get; set; }
        public bool bMostarAct { get; set; }
        public string vcComentarioAct { get; set; }
        public int idOrigen { get; set; }
        public int idProducto { get; set; }
        public DateTime dtFecha { get; set; }

    }
}
