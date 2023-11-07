namespace Cnx.Caiman.Core.DTOs
{
    public class ShipperInsertDto
    {
        public string Nombre {get; set; } 
        public int Zona {get; set; }
        public double Tarifa {get; set;} //* viene 1.0 por default
        public int CostoTarifa {get; set; } //* bandera si tienen tarifa especial
        public int Servirprioridad {get; set; }
        public int ICantSencillos {get; set;} // pedidos por viaje
        public int Maneja {get; set;} // viene de el storage transportista en 1 por default
        public int Propio {get;set;} 
        public double Cantidadporviaje {get;set;}
        public int Maniana {get; set;} 
        public int Tarde {get; set;}
        public int Noche {get; set;}
        public string Vc20usuario {get;set;}
        public string Vc12IdSAP {get;set;}
        public int IdTranspGeneral {get;set;}  
        public string Vc25NombreCorto {get;set;}
    }
}