using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Origin
{
    public class OriginDistanceDto
    {
        private decimal? ndistancia;
        private decimal? ntarifa;
        private decimal? ndistanciaHoras;
        public int IdOrigen { get; set; }
        public string Vc50Nombre { get; set; }
        public decimal? NDistancia {
            get
            {
                return this.ndistancia;
            } 
            set 
            {

                if (value == null)
                    this.ndistancia = 0;
                else
                    this.ndistancia = value;
            } 
        }
        public decimal? NTarifa {
            get
            {
                return this.ntarifa;
            }
            set
            {

                if (value == null)
                    this.ntarifa = 0;
                else
                    this.ntarifa = value;
            }
        }
        public decimal? NDistanciaHoras {
            get
            {
                return this.ndistanciaHoras;
            }
            set
            {

                if (value == null)
                    this.ndistanciaHoras = 0;
                else
                    this.ndistanciaHoras = value;
            }
        }
    }
}
