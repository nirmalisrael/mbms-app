using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.SupportData
{
    public class PurchaseStatusService
    {

        SQLServerHandler sQLServerHandler = new SQLServerHandler();
        public DataTable GetStatus(int statusId = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@StatusId", statusId) };
                return sQLServerHandler.ExecuteTable("[support].[sp_GetStatus]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }
        public void AddAndEditStatus(int statusId,string statusName)
        {
            try
            {
                    SqlParameter[] parameters = {
                new SqlParameter("@StatusId", statusId),
                new SqlParameter("@StatusName", statusName),
                new SqlParameter("@CreatedBy",1),
                new SqlParameter("@ModifiedBy",1)
                     };
                sQLServerHandler.ExecuteNonQuery("[support].[sp_InsertAndUpdateStatus]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        public void DeleteStatus(int statusId)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("StatuId", statusId),
                new SqlParameter("ModifiedBy",1)};
                sQLServerHandler.ExecuteNonQuery("[support].[sp_DeleteStatus]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }
}
