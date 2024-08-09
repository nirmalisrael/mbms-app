using System;
using System.Data;

namespace MBMS_APP.Framework.Helper
{
    public static class CommonHelper
    {
        public static void AddSerialNumberColumnToDataTable(DataTable dt)
        {
           try
            {
                DataColumn serialNumberColumn = new DataColumn("S. No", typeof(int));
                if (dt.Columns.Contains("S. No"))
                    dt.Columns.Remove("S. No");
                dt.Columns.Add(serialNumberColumn);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["S. No"] = i + 1;
                }
                serialNumberColumn.SetOrdinal(0);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }
}
