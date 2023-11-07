﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.Entities.QueryEntities.AsignacionViajes
{
    public class PlanAsignacionEnviarASicadiResult
    {
        public int idviaje { get; set; }
        public string vcsistema { get; set; }
        public string vccompany { get; set; }
        public string vccadena { get; set; }
        public string vczona { get; set; }
        public string vczonanombre { get; set; }
        public string vcsubzona { get; set; }
        public string vcsubzonanombre { get; set; }
        public string vcorigen { get; set; }
        public string vcorigennombre { get; set; }
        public string vccliente { get; set; }
        public string vcclientenombre { get; set; }
        public string vcdestino { get; set; }
        public string vcdestinonombre { get; set; }
        public string vcdestinocodigopostal { get; set; }
        public string vcdestinociudadestado { get; set; }
        public string vctransportista { get; set; }
        public string vctransportistanombre { get; set; }
        public string vctipounidadtransporte { get; set; }
        public string vcproducto { get; set; }
        public string vcproductonombre { get; set; }
        public string vctipoproducto { get; set; }
        public string vcunidadmedida { get; set; }
        public decimal ncantidadsolicitada { get; set; }
        public string vcentregasolicitada { get; set; }
        public string dtentregasolicitadaini { get; set; }
        public string dtentregasolicitadafin { get; set; }
        public string vcpedido { get; set; }
        public string vctipopedido { get; set; }
        public string vctipocliente { get; set; }
        public string vctipodestino { get; set; }
        public string vctipoentrega { get; set; }
        public string vcprioridad { get; set; }
        public string vccodigoretencion { get; set; }
        public int bconfirmardespacho { get; set; }
        public int bsincita { get; set; }
        public string vcviaje { get; set; }
        public string vctipoviaje { get; set; }
        public decimal ntiempotransitoorigendestino { get; set; }
        public decimal ndistanciaorigendestino { get; set; }
        public decimal ntarifaorigendestino { get; set; }
        public int bhoraespecifica { get; set; }
        public string dtentreganegociadaini { get; set; }
        public string dtentreganegociadafin { get; set; }
        public string dtentregacomprometidaoriginal { get; set; }
        public string dtentregacomprometida { get; set; }
        public string dtentregaoferta { get; set; }
        public string dtentregaestimadaini { get; set; }
        public string dtentregaestimadafin { get; set; }
        public string dtplan { get; set; }
        public string vcplanasignacion { get; set; }
        public DateTime dtevaluacion { get; set; }
        public string vcevaluacion { get; set; }
        public string vcfolio { get; set; }
        public string vcvehiculoplaneado { get; set; }
        public string vcvehiculoplaneadoplacas { get; set; }
        public string vcvehiculoejecucion { get; set; }
        public string vcvehiculoejecucionplacas { get; set; }
        public string dtcitadecarga { get; set; }
        public string dtllegada { get; set; }
        public string dtcarga { get; set; }
        public string dtsalida { get; set; }
        public string dtentrega { get; set; }
        public string dtcierre { get; set; }
        public int ilineasincluidas { get; set; }
        public string vcdetallexml { get; set; }
        public string vcdescripcionmaniobras { get; set; }
        public string vcnotas { get; set; }
        public string vcestatus { get; set; }
        public DateTime dtcreacion { get; set; }
        public DateTime dtmodificacion { get; set; }
        public string vcusuariocreacion { get; set; }
        public string vcusuariomodificacion { get; set; }
        public string vccompanyerp { get; set; }
        public string vccadenaerp { get; set; }
        public string vcorigenerp { get; set; }
        public string vcclienteerp { get; set; }
        public string vcdestinoerp { get; set; }
        public string vczonadestinoerp { get; set; }
        public string vctransportistaerp { get; set; }
        public string vctipounidadtransporteerp { get; set; }
        public string vcproductoerp { get; set; }
        public string vctipoproductoerp { get; set; }
        public string vcpedidoerp { get; set; }
        public string vctipopedidoerp { get; set; }
        public string tipoclienteerp { get; set; }
        public string vcviajeerp { get; set; }
        public string vctipoviajeerp { get; set; }
        public string vctipodestinoerp { get; set; }
        public string vctipoentregaerp { get; set; }
        public string vcprioridaderp { get; set; }
        public string vccodigoretencionerp { get; set; }
        public decimal ntiempotransitoorigendestinoerp { get; set; }
        public decimal ndistanciaorigendestinoerp { get; set; }
        public decimal ntarifaorigendestinoerp { get; set; }
        public string dtentregacomprometidaerp { get; set; }
        public string dtentregaofertadaerp { get; set; }
        public string dtentregaestimadaerp { get; set; }
        public string vcfolioerp { get; set; }
        public string vcvehiculoplaneadoerp { get; set; }
        public string vcvehiculoplaneadoplacaserp { get; set; }
        public string vcvehiculoejecucionerp { get; set; }
        public string vcvehiculoejecucionplacaserp { get; set; }
        public string dtcitadecargaerp { get; set; }
        public string dtllegadaerp { get; set; }
        public string dtcargaerp { get; set; }
        public string dtsalidaerp { get; set; }
        public string dtentregaerp { get; set; }
        public string dtclienteerp { get; set; }
        public string vcestatuserp { get; set; }
        public string vcusuario { get; set; }
        public string dtconciliacion { get; set; }
        public string vcconciliacionestatus { get; set; }
    }
}