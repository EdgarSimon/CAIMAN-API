using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Cemex.Core.Exceptions;
using ClosedXML.Excel;
using System.Reflection;

namespace Cemex.Core.Extension
{
    public static class XLFileExtension
    {
        public static string GetExcelFromEnumerableModel<T>(this XLWorkbook workbook, IEnumerable<T> dataExport, List<KeyValuePair<string, string>> columns, string worksheetName = "Reporte", Dictionary<string, Func<T, string>> functions = null)
        {
            try
            {
                var worksheet = workbook.Worksheets.Add(worksheetName);
                var currentRow = 2;
                var currentColumn = 1;

                foreach (var column in columns)
                {
                    worksheet.WriteColumnHeader(currentColumn++, column.Value);
                }

                foreach (var data in dataExport)
                {
                    currentColumn = 1;
                    foreach (var column in columns)
                    {
                        var value = GetValueColumn(column.Key, data);

                        if (functions != null && functions.ContainsKey(column.Key))
                        {
                            value = functions[column.Key](data);
                        }

                        worksheet.Cell(currentRow, currentColumn).Value = value;
                        currentColumn++;
                    }
                    currentRow++;
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
        private static string GetValueColumn(string columnKey, Object data)
        {
            var columnArray = columnKey.Split(".").ToList();
            if (columnArray.Count() > 1)
            {
                var lastColumn = columnArray.Last();
                Object value = null;
                columnArray.RemoveAt(columnArray.Count() - 1);
                foreach (var item in columnArray)
                {
                    value = (Object)data.GetType().GetProperty(item, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(data, null);
                }
                var dataValue = (value != null) ? value.GetType().GetProperty(lastColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(value, null) : null;
                return (dataValue != null) ? dataValue.ToString() : "";
            }
            else
            {
                var dataValue = data.GetType().GetProperty(columnKey, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(data, null);

                return (dataValue != null) ? dataValue.ToString() : "";
            }
        }

        public static void WriteColumnHeader(this IXLWorksheet worksheet, int columnNumber, string value)
        {
            worksheet.Cell(1, columnNumber).Value = value;
            worksheet.Cells().Style = XLWorkbook.DefaultStyle.Fill.SetBackgroundColor(XLColor.FromHtml("#003876"));
            worksheet.Cells().Style.Font.FontColor = XLColor.FromHtml("#FFFFFF");
            worksheet.Columns().Width = 35;
        }
    }
}