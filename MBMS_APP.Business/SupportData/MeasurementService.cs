using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.SupportData
{
    public class MeasurementService
    {
        SQLServerHandler sQLServerHandler = new SQLServerHandler();

        public DataTable GetMeasurement(int measurementId = 0, int itemId = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (measurementId > 0)
                {
                    SqlParameter[] param = { new SqlParameter("@MeasurementId", measurementId) };
                    dataTable = sQLServerHandler.ExecuteTable("[support].[sp_GetMeasurement]", param);
                }
                else if (itemId > 0)
                {
                    SqlParameter[] param = { new SqlParameter("@ItemId", itemId) };
                    dataTable = sQLServerHandler.ExecuteTable("[support].[sp_GetMeasurement]", param);
                }
                else
                {
                    dataTable = sQLServerHandler.ExecuteTable("[support].[sp_GetMeasurement]", null);
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }
        public void AddAndMeasurement(int measurementId, string measurementName)
        {
            try
            {
                SqlParameter[] parameters = {
                new SqlParameter("@MeasurementId", measurementId),
                new SqlParameter("@MeasurementName", measurementName),
                new SqlParameter("@CreatedBy",1),
                new SqlParameter("@ModifiedBy",1)
                     };
                sQLServerHandler.ExecuteNonQuery("[support].[sp_InsertAndUpdateMeasurement]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        public void DeleteMeasurement(int measurementId)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("MeasurementId", measurementId),
                new SqlParameter("ModifiedBy",1)};
                sQLServerHandler.ExecuteNonQuery("[support].[sp_DeleteMeasurement]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }
}
