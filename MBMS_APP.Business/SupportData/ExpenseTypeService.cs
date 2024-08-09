
using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.SupportData
{
    public class ExpenseTypeService
    {
        SQLServerHandler sQLServerHandler = new SQLServerHandler();

        public DataTable GetExpense(int expenseId = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@ExpenseId", expenseId) };
                return sQLServerHandler.ExecuteTable("[support].[sp_GetExpenseTypes]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }
        public void AddAndEditExpense(int expenseId, string expenseName,int expenseType)
        {
            try
            {
                SqlParameter[] parameters = {
                new SqlParameter("@ExpenseId", expenseId),
                new SqlParameter("@ExpenseName", expenseName),
                new SqlParameter("@IsDirect", expenseType),
                new SqlParameter("@CreatedBy",1),
                new SqlParameter("@ModifiedBy",1)
                     };
                sQLServerHandler.ExecuteNonQuery("[support].[AddOrEditExpense]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        public void DeleteExpense(int expenseId)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("StatuId", expenseId),
                new SqlParameter("ModifiedBy", 1)};
                sQLServerHandler.ExecuteNonQuery("[support].[sp_DeleteExpense]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }
}
