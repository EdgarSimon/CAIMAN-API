using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.PriorityList
{
    public class PriorityDemandDto
    {
        public int Folio { get; set; }
        public string Destino { get; set; }
        public string Producto { get; set; }
        public string Asignado { get; set; }
        //Inserta img o vacion
        public int imaniana { get; set; }
        //Inserta img o vacion
        public int itarde { get; set; }
        //Inserta img o vacion
        public int inoche { get; set; }
    }
}
