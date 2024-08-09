using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.Login
{
    public class LoginService
    {
        SQLServerHandler sqlServerHandler = new SQLServerHandler();

        public DataTable Login(string username, string password)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
                dataTable = sqlServerHandler.ExecuteTable("[mbms].[sp_LoginValidation]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }
    }



}
