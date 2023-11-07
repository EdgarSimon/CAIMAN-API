using System;

namespace Cnx.Caiman.Core.DTOs.Product
{
    public class ProductInsertDto
    {
        public string VcNombre {get; set; }
        public int ITipo {get; set; }
        public int IdZona {get; set; }
        public string VcClave {get; set; }
        public int IClaveSit {get; set; }
        public string Vc20usuario {get; set; }
        public string Vc25NombreCorto {get; set; }
        public DateTime? Dtfecha {get; set; }
    }
}