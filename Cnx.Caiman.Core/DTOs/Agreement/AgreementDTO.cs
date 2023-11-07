using System;

namespace Cnx.Caiman.Core.DTOs.Agreement
{
    public class AgreementDto
    {
        public int IdRestriccion { get; set; }
        public int IdZona { get; set; }
        public string Vc20Clave { get; set; }
        public string Vc255Descripcion { get; set; }
        public int? IdPerfil { get; set; }
        public int IdTransportista { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int ISirveA { get; set; }
        public int IHorario { get; set; }
        public int NMin { get; set; }
        public int NMax { get; set; }
        public int NCantidadMin { get; set; }
        public int NCantidadMax { get; set; }
        public bool BMensual { get; set; }
        public bool BMensualEntra { get; set; }
        public bool BActiva { get; set; }
        public string Vc100Predicado { get; set; }
        public string Vc20PivotePronunciacion { get; set; }
        public int? IApuntador { get; set; }
        public DateTime? DtPlanMensual { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public int? Ifrecuencia { get; set; }
        public int? IdRestriccionCopia { get; set; }
        public string BSirveA { get; set; }
        public int ITID { get; set; }
        public string EntidadAbsoluta { get; set; }
        public string EntidadSecundaria { get; set; }
        public int seleccionado
        {
            get
            {
                if (Convenio != null && Convenio.IdConvenios > 0)
                    return 1;
                else
                    return 0;
            }
        }
        public string ConveniosSeleccionados { get; set; }
        public RelTranslationRestrictionDto relTraduccionRestriccion { get; set; }
        public UserDto Usuario { get; set; }
        public RestrictionDto Restriccion2 { get; set; }
        public AgreementsDto Convenio { get; set; }
    }
}
