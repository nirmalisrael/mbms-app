using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.Expense
{
    public class ExpensesService
    {

        SQLServerHandler sqlServer = new SQLServerHandler();

        public void AddExpenseDetails(int expenseId, int expenseItemId, DateTime date, decimal amount)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[6];
                if (expenseId == 0)
                    parameters[0] = new SqlParameter("@ActionId", 1);
                else
                    parameters[0] = new SqlParameter("@ActionId", 4);
                parameters[1] = new SqlParameter("@ExpenseId", expenseId);
                parameters[2] = new SqlParameter("@ExpenseItemId", expenseItemId);
                parameters[3] = new SqlParameter("@Date", date);
                parameters[4] = new SqlParameter("@Amount", amount);
                parameters[5] = new SqlParameter("@CreatedBy", 1);
                sqlServer.ExecuteNonQuery("[mbms].[sp_ManageExpenses]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public DataSet GetExpensesByDates(DateTime startDate, DateTime endDate)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@ActionId", 2);
                parameters[1] = new SqlParameter("@FromDate", startDate);
                parameters[2] = new SqlParameter("@ToDate", endDate);
                ds = sqlServer.dsExecuteTable("[mbms].[sp_ManageExpenses]", parameters);
                string expenseName = ConversionHelper.ToString(ds.Tables[2].Rows[0]["ExpenseName"]);
                string category = ConversionHelper.ToString(ds.Tables[2].Rows[0]["Category"]);
                decimal amount = ConversionHelper.ToDecimal(ds.Tables[2].Rows[0]["Amount"]);
                ds.Tables[0].Rows.Add(0, 0, expenseName, DBNull.Value, category, amount);
                ds.Tables.RemoveAt(2);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ds;
        }

        public DataTable GetExpenseDetails(int expenseId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@ActionId", 3);
                parameters[1] = new SqlParameter("@ExpenseId", expenseId);
                dt = sqlServer.ExecuteTable("[mbms].[sp_ManageExpenses]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dt;
        }

        public void DeleteExpenseById(int expenseId)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@ActionId", 4);
                parameters[1] = new SqlParameter("@CreatedBy", 1);
                parameters[2] = new SqlParameter("@ExpenseId", expenseId);
                sqlServer.ExecuteNonQuery("[mbms].[sp_ManageExpenses]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }
}
