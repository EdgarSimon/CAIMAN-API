using System;
namespace Cnx.Caiman.Core.Entities.QueryEntities.Destino
{
    public class DestinoQuery
    {
        public int IdDestino { get; set; }
        public int IdZona { get; set; }
        public string Vc50Nombre { get; set; }
        public int IManiana { get; set; }
        public int ITarde { get; set; }
        public int INoche { get; set; }
        public bool BEsCliente { get; set; }
        public bool BVenta { get; set; }
        public string Vc10ZonaDestino { get; set; }
        public bool BInsertoSicadi { get; set; }
        public int? IdDestinoCopia { get; set; }
        public bool BMensual { get; set; }
        public bool BMensualEntra { get; set; }
        public bool BActivo { get; set; }
        public int IdSubZona { get; set; }
        public int? IClaveSicadi { get; set; }
        public int? IClaveSiclo { get; set; }
        public int? IClaveSit { get; set; }
        public DateTime? DtPlanMensual { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public bool? BAutoAbasto { get; set; }
        public bool? BPronostico { get; set; }
        public string Vc12claveSap { get; set; }
        public string Cedis { get; set; }
        public string VcZonaSap { get; set; }
        public string Nvc25NombreCorto { get; set; }
        public string Vc25NombreCorto { get; set; }
        public bool? BDestinoRelBandera {get; set; }
        public bool? ICantReg {get; set; }
        public string VcDestinoRel { get; set; }

        public DestinoUbicacion DestinoUbicacion { get; set; }
        public SubZona SubZona { get; set; }
        public Cedi Cedi { get; set; }
    }
}