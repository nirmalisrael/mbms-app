using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.SupportData
{
    public class ReferenceService
    {
        SQLServerHandler sQLServerHandler = new SQLServerHandler();

        public bool GetReferredData(int actionId, int id)
        {
            bool result = false;
            try
            {
                DataTable dataTable = new DataTable();
                SqlParameter[] param = 
                {
                    new SqlParameter("@ActionId", actionId),
                     new SqlParameter("@Id", id)
                };
                dataTable = sQLServerHandler.ExecuteTable("[support].[sp_GetIsReferred]", param);
                if (dataTable.Rows.Count > 0)
                {
                    int referedCount = ConversionHelper.ToInt32(dataTable.Rows[0]["IsReferred"]);
                    if (referedCount > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return result;
        }
    }
}
