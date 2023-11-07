using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.Entities.QueryEntities.CuboDiario
{
    public class CuboDiario
    {
        public int IdOrigen { get; set; }
        public string Origen { get; set; }
        public int IdTransportista { get; set; }
        public string Transportista { get; set; }
        public decimal nTarifa { get; set; }
        public int iCantSencillos { get; set; }
        public int nCantidadPorViaje { get; set; }
    }
}
