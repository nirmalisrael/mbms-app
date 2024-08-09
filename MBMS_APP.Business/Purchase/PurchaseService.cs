using MBMS_APP.Business.Models;
using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.Purchase
{
    public class PurchaseService
    {
        SQLServerHandler sqlServerHandler = new SQLServerHandler();

        public DataSet GetPurchaseRequest(int requestId = 0, int statusId = 0, short isDirectExpense = 0)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlParameter[] sqlParameters = {
                    new SqlParameter("@RequestId", requestId),
                    new SqlParameter("@StatusId", statusId),
                    new SqlParameter("@RoleId", 1),
                    new SqlParameter("@IsDirectExpense", isDirectExpense)
                };
                dataSet = sqlServerHandler.dsExecuteTable("[mbms].[sp_GetPurchaseOrders]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataSet;
        }

        public void InsertAndUpdatePurchaseRequest(PurchaseRequest purchaseRequest, string ItemIdList = "", string RequestedQuantity = "", string amount = "")
        {
            try
            {
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@RequestId", purchaseRequest.RequestId),
                    new SqlParameter("@RequestName", purchaseRequest.RequestName),
                    new SqlParameter("@StatusId", purchaseRequest.StatusId),
                    new SqlParameter("@IsDirectExpense", purchaseRequest.IsDirectExpense),
                    new SqlParameter("@AmountList", amount),
                    new SqlParameter("@CreatedBy", 1),
                    new SqlParameter("@ModifiedBy", 1),
                    new SqlParameter("@ItemIdList", ItemIdList),
                    new SqlParameter("@RequestedQuantityList", RequestedQuantity)
                };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_InserAndUpdatePurchaseRequest]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public void UpdatePurchaseRequest(int requestId, int statusId, string requestXrefIdList = "", 
            string quantityList = "", string amountList = "", string itemIdList = "")
        {
            try
            {
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@RequestId", requestId),
                    new SqlParameter("@StatusId", statusId),
                    new SqlParameter("@RequestXrefIdList", requestXrefIdList),
                    new SqlParameter("@QuantityList", quantityList),
                    new SqlParameter("@AmountList", amountList),
                    new SqlParameter("@ItemIdList", itemIdList),
                    new SqlParameter("@ModifiedBy", 1)
                };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_UpdatePurchaseRequest]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public void UpdateDraftPurchaseRequest(PurchaseRequest request, string itemIdList = "", string quantityList = "", int actionId = 0)
        {
            try {
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@RequestId", request.RequestId),
                    new SqlParameter("@StatusId", request.StatusId),
                    new SqlParameter("@ItemIdList", itemIdList),
                    new SqlParameter("@QuantityList", quantityList),
                    new SqlParameter("@RequestName", request.RequestName),
                    new SqlParameter("@ActionId", actionId),
                    new SqlParameter("@ModifiedBy", 1)
                };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_UpdatePurchaseRequest]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        public void DeletePurchaseRequest(int requestId = 0)
        {
            try
            {
                SqlParameter[] sqlParameters = {
                    new SqlParameter("@RequestId", requestId),
                    new SqlParameter("@ModifiedBy", 1)
                };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_DeletePurchaseOrder]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public DataTable GetPurchaseRequestItems(int requestId)
        {
            DataTable purhaseReqeustItems = new DataTable();
            try
            {
                SqlParameter[] sqlParameters = { new SqlParameter("@RequestId", requestId) };
                purhaseReqeustItems = sqlServerHandler.ExecuteTable("[mbms].[sp_GetPurchaseRequestItems]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return purhaseReqeustItems;
        }

        public DataTable GetPurchaseRequestItem(int requestXrefId)
        {
            DataTable puchaseRequestItem = new DataTable();
            try
            {
                SqlParameter[] sqlParameters = { new SqlParameter("@RequestXrefId", requestXrefId) };
                sqlServerHandler.ExecuteTable("[mbms].[sp_GetPurchaseRequestItem]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return puchaseRequestItem;
        }

        public void DeletePurchaseRequestItem(int requestXrefId)
        {
            try
            {
                SqlParameter[] sqlParameters = {
                    new SqlParameter("@RequestXrefId", requestXrefId),
                    new SqlParameter("@ModifiedBy", 1)
                };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_DeletePurchaseRequestItem]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public DataSet GetCompletedRequests(DateTime startDate, DateTime endDate)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@FromDate", startDate),
                    new SqlParameter("@ToDate", endDate)
                };
                dataSet = sqlServerHandler.dsExecuteTable("[mbms].[sp_GetCompletedRequestes]", sqlParameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataSet;
        }
    }
}
