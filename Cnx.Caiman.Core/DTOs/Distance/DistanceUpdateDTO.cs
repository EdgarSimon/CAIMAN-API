namespace Cnx.Caiman.Core.DTOs.Distance
{
    public class DistanceUpdateDto
    {
        public int IdEnlaceManual {get;set;}
        public int IdOrigen {get;set;}
        public int IdProducto {get;set;}
        public int IdDestino {get;set;}
        public double Tarifa {get;set;}
        public double Distancia {get;set;}
        public string Vc20usuario {get;set;}
    }
}