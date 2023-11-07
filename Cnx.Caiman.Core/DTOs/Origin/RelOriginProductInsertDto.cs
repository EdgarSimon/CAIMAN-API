using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.Origin
{
    public class RelOriginProductInsertDto
    {
        public int IdProducto { get; set; }
        public int IdOrigen { get; set; }
        public float Precio { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}