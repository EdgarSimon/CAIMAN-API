using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class BorrameTarifa
    {
        public string Clcd { get; set; }
        public string Tconexion { get; set; }
        public string Destino { get; set; }
        public string NomDestino { get; set; }
        public double? Tarifa { get; set; }
        public string Umedida { get; set; }
        public string NomOrigen { get; set; }
        public string Origen { get; set; }
        public string NomCantera { get; set; }
    }
}
