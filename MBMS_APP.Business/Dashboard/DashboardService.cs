using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;

namespace MBMS_APP.Business.Dashboard
{
    public class DashboardService
    {
        SQLServerHandler sqlServer = new SQLServerHandler();

        public DataTable GetDashboardDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = sqlServer.ExecuteTable("[mbms].[sp_GetDashboardDetails]", null);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dt;
        }
    }
}
