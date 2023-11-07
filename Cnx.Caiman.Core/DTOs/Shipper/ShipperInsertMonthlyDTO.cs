using System;

namespace Cnx.Caiman.Core.DTOs.Shipper
{
    public class ShipperInsertMonthlyDto
    {
        public string Nombre {get;set;}
        public int Zona {get;set;}
        public double Tarifa {get; set;}
        public int CostoTarifa {get;set;}
        public int Servirprioridad {get;set;}
        public int ICantSencillos{get;set;} 
        public int Maneja {get; set;}
        public int ClaveSit {get; set;}
        public int Propio {get; set;}
        public DateTime Dtfecha {get; set;}
        public string Vc20usuario {get; set;}
    }
}