using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Cnx.Caiman.Core.CustomEntities;
using Cnx.Caiman.Core.DTOs;

namespace Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory
{
    public class ReaderDataFromRateHierarchy : DataTableExport, IReaderDataFromImportFIle
    {
        private readonly ProcFileDto procFile;
        public ReaderDataFromRateHierarchy(ProcFileDto procFile): base(procFile)
        {
            this.procFile = procFile;
        }
        public DataTableReaderFile GetDataAndStoreFromFile()
        {
            try
            {
                DataTable dt = this.GetDataTable();
                return this.GetDataResponse("evo_spTarifaJerarquia_Interfaz_Insertar", dt);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public override DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "dbo.ImportarFileTarifaJerarquia";
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

            var J2 = new DataColumn("J2", typeof(string));
            J2.AllowDBNull = true;
            dt.Columns.Add(J2);

            var J3 = new DataColumn("J3", typeof(string));
            J3.AllowDBNull = true;
            dt.Columns.Add(J3);

            var J5 = new DataColumn("J5", typeof(string));
            J5.AllowDBNull = true;
            dt.Columns.Add(J5);

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
