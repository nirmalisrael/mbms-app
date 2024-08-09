using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.Stock
{
    public class StockService
    {
        SQLServerHandler sqlServerHandler = new SQLServerHandler();

        public DataTable GetGoodsReport(DateTime fromDate, DateTime toDate)
        {
            DataTable result = new DataTable();
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };
                result = sqlServerHandler.ExecuteTable("[mbms].[sp_GetGoodsReport]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return result;
        }
    }
}
