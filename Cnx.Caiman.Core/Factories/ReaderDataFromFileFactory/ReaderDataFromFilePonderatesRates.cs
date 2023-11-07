using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Cnx.Caiman.Core.CustomEntities;
using Cnx.Caiman.Core.DTOs;

namespace Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory
{
    public class ReaderDataFromFilePonderatesRates : DataTableExport, IReaderDataFromImportFIle
    {
        private readonly ProcFileDto procFile;
        public ReaderDataFromFilePonderatesRates(ProcFileDto procFile): base(procFile)
        {
            this.procFile = procFile;
        }
        public DataTableReaderFile GetDataAndStoreFromFile()
        {
            try
            {
                DataTable dt = this.GetDataTable();
                return this.GetDataResponse("Evo_spTarifaPonderada_Interfaz_Insertar", dt);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public override DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "dbo.ImportFilePondarateRates";
            dt.ExtendedProperties.Add("Filename", this.procFile.File.FileName);

            var DtAccion = new DataColumn("DtAccion", typeof(string));
            DtAccion.AllowDBNull = false;
            dt.Columns.Add(DtAccion);

            var Usuario = new DataColumn("Usuario", typeof(string));
            Usuario.AllowDBNull = false;
            dt.Columns.Add(Usuario);

            var Planta = new DataColumn("Planta", typeof(string));
            Planta.AllowDBNull = true;
            dt.Columns.Add(Planta);

            var NombrePlanta = new DataColumn("NombrePlanta", typeof(string));
            NombrePlanta.AllowDBNull = true;
            dt.Columns.Add(NombrePlanta);

            var ShipFrom = new DataColumn("ShipFrom", typeof(string));
            ShipFrom.AllowDBNull = true;
            dt.Columns.Add(ShipFrom);

            var Destino = new DataColumn("Destino", typeof(string));
            Destino.AllowDBNull = true;
            dt.Columns.Add(Destino);

            var Material = new DataColumn("Material", typeof(string));
            Material.AllowDBNull = true;
            dt.Columns.Add(Material);

            var UM = new DataColumn("UM", typeof(string));
            UM.AllowDBNull = true;
            dt.Columns.Add(UM);

            var Importe = new DataColumn("Importe", typeof(string));
            Importe.AllowDBNull = true;
            dt.Columns.Add(Importe);

            return dt;
        }
    }
}
