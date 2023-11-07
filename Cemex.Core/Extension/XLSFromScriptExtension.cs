using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cemex.Core.Exceptions;
using ClosedXML.Excel;

namespace Cemex.Core.Extension
{
    public static class XLSFromScriptExtension
    {
        public static string GetExcelFromStoreQuery(this XLWorkbook workbook, List<KeyValuePair<string, IEnumerable<dynamic>>> dataExport, Dictionary<string, Func<dynamic, string>> functions = null)
        {
            try
            {
                var countSheets = 1;
                foreach(var report in dataExport)
                {
                    var worksheet = workbook.Worksheets.Add(report.Key + "-" + countSheets);
                    countSheets++;
                    var currentRow = 2;
                    var currentColumn = 1;
                    bool hasHeader = false;
                    foreach (var rows in report.Value)
                    {
                        currentColumn = 1;
                        foreach (var column in rows)
                        {
                            var fields = (KeyValuePair<string, object>)column;
                            var value = fields.Value?.ToString();
                            if (functions != null && functions.ContainsKey(column.Key))
                            {
                                value = functions[column.Key](fields);
                            }
                            if(!hasHeader)
                            {
                                worksheet.WriteColumnHeaderScript(currentColumn, fields.Key);
                            }
                            worksheet.Cell(currentRow, currentColumn).Value = value;
                            currentColumn++;
                        }
                        hasHeader = true;
                        currentRow++;
                    }
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    string base64 = Convert.ToBase64String(content);
                    return base64;
                }
            }
            catch (System.Exception ex)
            {
                throw new BusinessException("ColumnNotFoundException");
            }
        }
        public static void WriteColumnHeaderScript(this IXLWorksheet worksheet, int columnNumber, string value)
        {
            worksheet.Cell(1, columnNumber).Value = value;
            worksheet.Columns().Width = 35;
        }
    }
}
