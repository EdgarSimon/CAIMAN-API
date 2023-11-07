using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.Product
{
    public class ProductShortInsertDto
    {
        public string VcNombre {get; set; }
        public int IdZona {get; set; }
        public int IdProdGral {get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}