using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Interfaces.Repositories;
using ClosedXML.Excel;

namespace Cnx.Caiman.Core.Factories.ScriptFactory
{
    public class ScriptExecuteUpdateCVP : IScriptReader
    {
        private readonly IScriptRepository scriptRepository;
        public ScriptExecuteUpdateCVP(IScriptRepository scriptRepository)
        {
            this.scriptRepository = scriptRepository;
        }
        public async Task<string> GetResponseStoreProcedure(object parameters, StreamContent file = null)
        {
            DataTable dataTable = this.ReadFileXLSToDataTable(file, parameters);
            await this.scriptRepository.ExecuteUpdateCVP(dataTable);
            return "";
        }

        public string GetResponseType()
        {
            return "";
        }

        private DataTable ReadFileXLSToDataTable(StreamContent file, object parameters)
        {
            DataTable dt = this.GetDataTableCVP(parameters);
            using (XLWorkbook workbook = new XLWorkbook(file.ReadAsStream()))
            {
                var worksheet = workbook.Worksheet(1);
                var columnsUsed = worksheet.ColumnsUsed().Count();
                var rowCount = worksheet.RowsUsed().Count();
                for (int row = 2; row <= rowCount; row++)
                {
                    var dataRow = dt.NewRow();
                    for (var column = 1; column <= dt.Columns.Count; column++)
                    {
                        var columnFile = worksheet.Cell(row, column).Value.ToString().Trim();
                        if (columnFile == null || columnFile == String.Empty)
                            dataRow[column - 1] = DBNull.Value;//columnFile == null || columnFile == string.Empty ? DBNull.Value : columnFile;
                        else
                        {
                            dataRow[column - 1] = columnFile;
                        }

                    }
                    dt.Rows.Add(dataRow);
                }
                return dt;
            }

        }

        private DataTable GetDataTableCVP(object parameters)
        {
            var _object = (IDictionary<string,object>)parameters;
            string dtFecha = (string)_object["dtFecha"];

            DataTable dt = new DataTable();
            dt.TableName = "dbo.UpdateCVP";
            dt.ExtendedProperties.Add("dtFecha", dtFecha);

            var DtAccion = new DataColumn("idorigen", typeof(string));
            DtAccion.AllowDBNull = false;
            dt.Columns.Add(DtAccion);

            var Usuario = new DataColumn("costo", typeof(float));
            Usuario.AllowDBNull = false;
            dt.Columns.Add(Usuario);

            return dt;
        }
    }
}