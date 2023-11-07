using System;
namespace Cnx.Caiman.Core.Entities
{
    public class Distancia
    {
        public int IdDistancia {get;set;}
        public string Nombre {get;set;}
        public string Producto {get;set;}
        public int DistanciaF {get;set;}
        public double? Distancia_F {get;set;}
        public double? Tarifa_F {get;set;}
        public DateTime? DtActualizacion {get;set;}
        public string Vc20UsuarioActualizacion {get;set;}
        public int IdOrigen {get;set;}
        public int IdPRoducto {get;set;}
        public int IdDestino {get;set;}
        public double? Tarifa_M {get;set;}
        public double? Tarifa_P {get;set;}
        public double? Tarifa_ED {get;set;}
        public double? Tarifa_J {get;set;}
        public int? IdEnlaceManual {get;set;}
        public bool EnProceso {get;set;}
        public double? NDistancia {get;set;}
        public SubZona SubZona {get;set;}
        public Cedi Cedi {get;set;}
        
    }
}