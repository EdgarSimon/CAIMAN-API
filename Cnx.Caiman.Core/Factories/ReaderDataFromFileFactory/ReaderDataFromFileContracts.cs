using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Cnx.Caiman.Core.CustomEntities;
using Cnx.Caiman.Core.DTOs;

namespace Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory
{
    public class ReaderDataFromFileContracts : DataTableExport, IReaderDataFromImportFIle
    {
        private readonly ProcFileDto procFile;
        public ReaderDataFromFileContracts(ProcFileDto procExcel) : base(procExcel)
        {
            this.procFile = procExcel;
        }

        public DataTableReaderFile GetDataAndStoreFromFile()
        {
            try
            {
                DataTable dt = this.GetDataTable();
                return this.GetDataResponse("evo_spContrato_Interfaz_Insertar", dt);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public override DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "dbo.ImportarDataContratos";
            dt.ExtendedProperties.Add("Filename", this.procFile.File.FileName);

            var DtAccion = new DataColumn("DtAccion", typeof(string));
            DtAccion.AllowDBNull = false;
            dt.Columns.Add(DtAccion);

            var Usuario = new DataColumn("Usuario", typeof(string));
            Usuario.AllowDBNull = false;
            dt.Columns.Add(Usuario);

            var IdContrato = new DataColumn("IdContrato", typeof(string));
            IdContrato.AllowDBNull = true;
            dt.Columns.Add(IdContrato);

            var vcSAP_Origen = new DataColumn("vcSAP_Origen", typeof(string));
            vcSAP_Origen.AllowDBNull = true;
            dt.Columns.Add(vcSAP_Origen);

            var DescOrigen = new DataColumn("DescOrigen", typeof(string));
            DescOrigen.AllowDBNull = true;
            dt.Columns.Add(DescOrigen);

            var PagaFlete = new DataColumn("PagaFlete", typeof(string));
            PagaFlete.AllowDBNull = true;
            dt.Columns.Add(PagaFlete);

            var DescPagaFlete = new DataColumn("DescPagaFlete", typeof(string));
            DescPagaFlete.AllowDBNull = true;
            dt.Columns.Add(DescPagaFlete);

            var PlazoLicitacion = new DataColumn("PlazoLicitacion", typeof(string));
            PlazoLicitacion.AllowDBNull = true;
            dt.Columns.Add(PlazoLicitacion);

            var vcSAP_Producto = new DataColumn("vcSAP_Producto", typeof(string));
            vcSAP_Producto.AllowDBNull = true;
            dt.Columns.Add(vcSAP_Producto);

            var DescProducto = new DataColumn("DescProducto", typeof(string));
            DescProducto.AllowDBNull = true;
            dt.Columns.Add(DescProducto);

            var UnidadMedida = new DataColumn("UnidadMedida", typeof(string));
            UnidadMedida.AllowDBNull = true;
            dt.Columns.Add(UnidadMedida);

            var Precio = new DataColumn("Precio", typeof(string));
            Precio.AllowDBNull = true;
            dt.Columns.Add(Precio);

            var Cedis = new DataColumn("Cedis", typeof(string));
            Cedis.AllowDBNull = true;
            dt.Columns.Add(Cedis);

            var DescCedis = new DataColumn("DescCedis", typeof(string));
            DescCedis.AllowDBNull = true;
            dt.Columns.Add(DescCedis);

            var Ruta = new DataColumn("Ruta", typeof(string));
            Ruta.AllowDBNull = true;
            dt.Columns.Add(Ruta);

            return dt;
        }
    }
}
