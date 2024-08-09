using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.SupportData
{
    public class ItemService
    {
        SQLServerHandler sQLServerHandler = new SQLServerHandler();
        public DataTable GetItems(int itemId = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@ItemId", itemId) };
                return sQLServerHandler.ExecuteTable("[support].[sp_GetItemDetails]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }
        public void AddAndEditItems(int itemId , string itemName , int measurementId)
        {
            try
            {
                SqlParameter[] parameters = {
                new SqlParameter("@ItemId", itemId),
                new SqlParameter("@ItemName", itemName),
                new SqlParameter("MeasurementId",measurementId),
                new SqlParameter("@CreatedBy",1),
                new SqlParameter("@ModifiedBy",1)
                     };
                sQLServerHandler.ExecuteNonQuery("[support].[sp_InsertAndUpdateItem]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        public void DeleteItem(int itemId)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("ItemId", itemId),
                new SqlParameter("ModifiedBy",1)};
                sQLServerHandler.ExecuteNonQuery("[support].[sp_DeleteItem]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public DataTable GetGoodsAvailability()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = sQLServerHandler.ExecuteTable("[mbms].[sp_GetGoodsAvailability]", null);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dt;
        }

        public void AddUtilizedItem(int itemId, decimal quantity)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@ItemId", itemId),
                    new SqlParameter("@UtilizedQuantity", quantity),
                    new SqlParameter("@CreatedBy", 1)
                };
                sQLServerHandler.ExecuteNonQuery("[mbms].[sp_AddUtilizedItem]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }
}
