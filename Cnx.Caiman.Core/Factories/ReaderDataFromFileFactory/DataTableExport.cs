using System;
using System.Data;
using System.IO;
using System.Linq;
using Cnx.Caiman.Core.CustomEntities;
using Cnx.Caiman.Core.DTOs;
using Cemex.Core.Exceptions;
using ClosedXML.Excel;

namespace Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory
{
    public abstract class DataTableExport
    {
        private readonly ProcFileDto procFile;
        private readonly string[] supportedExcelTypes = new[] { "xls", "xlsx", "csv" };
        private readonly string[] supportedTxtTypes = new[] { "txt" };
        public DataTableExport(ProcFileDto procFile)
        {
            this.procFile = procFile;
        }

        public abstract DataTable GetDataTable();

        public DataTableReaderFile GetDataResponse(string storeProcedure, DataTable dt)
        {
            var fileextension = Path.GetExtension(this.procFile.File.FileName).Substring(1);
            if (this.supportedExcelTypes.Contains(fileextension))
                dt = this.GetDataFromXlsFile(dt);
            else if (this.supportedTxtTypes.Contains(fileextension))
                dt = this.GetDataTableFromTxtFile(dt);
            else
                throw new BusinessException("FileExtensionNotAllowed");
            return new DataTableReaderFile(storeProcedure, dt);
        }

        private DataTable GetDataFromXlsFile(DataTable dt)
        {
            using (XLWorkbook workbook = new XLWorkbook(this.procFile.File.OpenReadStream()))
            {
                var worksheet = workbook.Worksheet(1);
                var columnsUsed = worksheet.ColumnsUsed().Count();
                var rowCount = worksheet.RowsUsed().Count();
                for (int row = 1; row <= rowCount; row++)
                {
                    var dataRow = dt.NewRow();
                    dataRow[0] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    dataRow[1] = this.procFile.Vc20usuario;
                    for (var column = 2; column < dt.Columns.Count; column++)
                    {
                        var columnFile = worksheet.Cell(row, column - 1).Value.ToString().Trim();
                        if (columnFile == null || columnFile == String.Empty)
                            dataRow[column] = DBNull.Value;//columnFile == null || columnFile == string.Empty ? DBNull.Value : columnFile;
                        else
                        {
                            dataRow[column] = columnFile;
                        }

                    }
                    dt.Rows.Add(dataRow);
                }
                return dt;
            }

        }

        private DataTable GetDataTableFromTxtFile(DataTable dt)
        {
            using (var reader = new StreamReader(this.procFile.File.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    var records = line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    var dataRow = dt.NewRow();
                    dataRow[0] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    dataRow[1] = this.procFile.Vc20usuario;
                    for (var i = 2; i < dt.Columns.Count && records.Length > 0; i++)
                    {
                        var indexRecord = i - 2;
                        if (indexRecord < records.Length)
                            dataRow[i] = records[indexRecord];
                        else
                            dataRow[i] = DBNull.Value;
                    }
                    dt.Rows.Add(dataRow);
                }
                return dt;
            }
        }
    }
}
