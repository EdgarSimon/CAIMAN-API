using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cnx.Caiman.Core.CustomEntities;
using Cnx.Caiman.Core.DTOs;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;

namespace Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory
{
    public class ReaderDataFromFileRoutes : DataTableExport, IReaderDataFromImportFIle
    {
        private readonly ProcFileDto procExcel;
        public ReaderDataFromFileRoutes(ProcFileDto procExcel) : base(procExcel)
        {
            this.procExcel = procExcel;
        }
        public DataTableReaderFile GetDataAndStoreFromFile()
        {
            try
            {
                DataTable dt = this.GetDataTable();
                return this.GetDataResponse("evo_spRutas_Interfaz_Insertar", dt);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public override DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "dbo.ExportarRutasInterfaz";
            dt.ExtendedProperties.Add("Filename", this.procExcel.File.FileName);

            var DtAccion = new DataColumn("DtAccion", typeof(string));
            DtAccion.AllowDBNull = false;
            dt.Columns.Add(DtAccion);

            var Usuario = new DataColumn("Usuario", typeof(string));
            Usuario.AllowDBNull = false;
            dt.Columns.Add(Usuario);

            var Ruta = new DataColumn("Ruta", typeof(string));
            Ruta.AllowDBNull = false;
            dt.Columns.Add(Ruta);

            var UM = new DataColumn("UM", typeof(string));
            UM.AllowDBNull = false;
            dt.Columns.Add(UM);

            var Importe = new DataColumn("Importe", typeof(string));
            Importe.AllowDBNull = false;
            dt.Columns.Add(Importe);

            var ODM = new DataColumn("ODM", typeof(string));
            ODM.AllowDBNull = false;
            dt.Columns.Add(ODM);

            var Cedis = new DataColumn("Cedis", typeof(string));
            Cedis.AllowDBNull = false;
            dt.Columns.Add(Cedis);

            var Fecha = new DataColumn("Fecha", typeof(string));
            Fecha.AllowDBNull = false;
            dt.Columns.Add(Fecha);

            return dt;
        }
    }
}