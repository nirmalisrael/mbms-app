using System;
using System.Data;
using System.Text;

namespace MBMS_APP.Framework.Helper
{
    public static class QueryHelper
    {
        public static string ConvertColumnToCsv(DataTable dataTable, string columnName)
        {
            if (dataTable == null || !dataTable.Columns.Contains(columnName))
            {
                throw new ArgumentException("Invalid DataTable or column name.");
            }

            StringBuilder csvData = new StringBuilder();

            foreach (DataRow row in dataTable.Rows)
            {
                string cellData = row[columnName] != null ? row[columnName].ToString() : string.Empty;

                // Escape special characters by wrapping the cell data in quotes if it contains a comma, newline, or quote
                if (cellData.Contains(",") || cellData.Contains("\n") || cellData.Contains("\""))
                {
                    cellData = "\"" + cellData.Replace("\"", "\"\"") + "\"";
                }

                csvData.Append(cellData + ",");
            }

            // Remove the trailing comma
            if (csvData.Length > 0)
            {
                csvData.Length--;
            }

            return csvData.ToString();
        }
    }
}
