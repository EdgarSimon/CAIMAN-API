using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Cnx.Caiman.Core.DTOs
{
    public class ProcFileDto
    {
        public IFormFile File { get; set; }
        [JsonIgnore]
        public string Vc20usuario { get; set; }
    }
}