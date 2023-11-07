using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Cnx.Caiman.Core.CustomEntities;
using Cnx.Caiman.Core.DTOs;
using Cemex.Core.Exceptions;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;

namespace Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory
{
    public class ReaderDataFromFileCostOverrun: DataTableExport, IReaderDataFromImportFIle
    {
        private readonly ProcFileDto procExcel;

        public ReaderDataFromFileCostOverrun(ProcFileDto procExcel) : base(procExcel)
        {
            this.procExcel = procExcel;
        }

        public DataTableReaderFile GetDataAndStoreFromFile()
        {
            try
            {
                DataTable dt = this.GetDataTable();
                return this.GetDataResponse("EVO_spSobreCostoImportar", dt);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public override DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "dbo.ImportarFileSobreCostos";
            dt.ExtendedProperties.Add("Filename", this.procExcel.File.FileName);

            var DtAccion = new DataColumn("DtAccion", typeof(string));
            DtAccion.AllowDBNull = false;
            dt.Columns.Add(DtAccion);

            var Usuario = new DataColumn("Usuario", typeof(string));
            Usuario.AllowDBNull = false;
            dt.Columns.Add(Usuario);

            var producto = new DataColumn("IdProducto", System.Type.GetType("System.Int32"));
            producto.AllowDBNull = false;
            dt.Columns.Add(producto);

            var origen = new DataColumn("IdOrigen", System.Type.GetType("System.Int32"));
            origen.AllowDBNull = false;
            dt.Columns.Add(origen);

            var CostoPorCalidad = new DataColumn("CostoPorCalidad", typeof(decimal));
            CostoPorCalidad.AllowDBNull = false;
            dt.Columns.Add(CostoPorCalidad);

            var Kilogramos = new DataColumn("Kilogramos", typeof(decimal));
            Kilogramos.AllowDBNull = true;
            Kilogramos.DefaultValue = null;
            dt.Columns.Add(Kilogramos);

            var CostoCemento = new DataColumn("CostoCemento", typeof(decimal));
            CostoCemento.AllowDBNull = true;
            CostoCemento.DefaultValue = null;
            dt.Columns.Add(CostoCemento);

            return dt;
        }
    }
}
