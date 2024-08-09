using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System.Data.SqlClient;
using System.Data;
using System;

namespace MBMS_APP.Business.MessBill
{
    public class MessBillService
    {
        SQLServerHandler sqlServerHandler = new SQLServerHandler();

        public DataTable GenerateMessBill(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };
                dt = sqlServerHandler.ExecuteTable("[mbms].[sp_GenerateMessBill]", sqlParameters);
            }
            catch (Exception e)
            {
                new ErrorLog().WriteLog(e);
            }
            return dt;
        }

        public DataTable GetMessBillList(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@ActionId", 3),
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };
                dt = sqlServerHandler.ExecuteTable("[mbms].[sp_BillDetails]", sqlParameters);
            }
            catch (Exception e)
            {
                new ErrorLog().WriteLog(e);
            }
            return dt;
        }

        public void SaveMessBill(
        string userIdList,
        DateTime dateFrom,
        DateTime dateTo,
        string noOfPresentList,
        string noOfLeavesList,
        string payableAmountList,
        decimal costPerDay,
        int actionId )
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ActionId", SqlDbType.Int) { Value = actionId },
                    new SqlParameter("@UserIdList", SqlDbType.VarChar) { Value = userIdList},
                    new SqlParameter("@FromDate", SqlDbType.Date) { Value = dateFrom },
                    new SqlParameter("@ToDate", SqlDbType.Date) { Value = dateTo },
                    new SqlParameter("@NoOfPresentList", SqlDbType.VarChar) { Value = noOfPresentList },
                    new SqlParameter("@NoOfLeavesList", SqlDbType.VarChar) { Value = noOfLeavesList },
                    new SqlParameter("@PayableAmountList", SqlDbType.VarChar) { Value = payableAmountList },
                    new SqlParameter("@CostPerDay", SqlDbType.VarChar) { Value = costPerDay },
                    new SqlParameter("@CreatedBy", SqlDbType.Int) { Value = 1 }
                };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_BillDetails]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public DataTable CheckExistMessBill(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ActionId", SqlDbType.Int) { Value = 2 },
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate) };

                dataTable = sqlServerHandler.ExecuteTable("[mbms].[sp_BillDetails]", parameters);
              
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }
    }
}

