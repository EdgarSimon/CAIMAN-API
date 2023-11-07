using System;

namespace Cnx.Caiman.Core.DTOs.Product
{
    public class ProductoRelationMonthlyUpdateDto
    {
        public int IAcceso {get; set; }
        public int IdPagina {get; set; }
        public DateTime DtFecha {get; set; }
        public string VcUsuario {get; set; }
    }
}