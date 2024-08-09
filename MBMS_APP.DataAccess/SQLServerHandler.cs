using MBMS_APP.Framework.Helper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.DataAccess
{
    public class SQLServerHandler
    {

        public string sConn = "";

        public SQLServerHandler()
        {
            sConn = ConfigurationManager.ConnectionStrings["MBMSApp"].ConnectionString;
        }

        public int ExecuteNonQuery(string sQuery, SqlParameter[] objSqlPar, CommandType commandType = CommandType.StoredProcedure)
        {
            int result = 0;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(sConn))
                {
                    sqlcon.Open();
                    using (SqlCommand Cmd = new SqlCommand(sQuery, sqlcon))
                    {
                        Cmd.CommandType = commandType;
                        Cmd.Parameters.AddRange(objSqlPar);
                        result = Cmd.ExecuteNonQuery();
                    }
                    sqlcon.Close();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return result;
        }
        public object ExecuteScalar(string sQuery, SqlParameter[] objSqlPar, CommandType commandType = CommandType.StoredProcedure)
        {
            object Result = new object();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(sConn))
                {
                    sqlcon.Open();
                    using (SqlCommand Cmd = new SqlCommand(sQuery, sqlcon))
                    {
                        Cmd.CommandType = commandType;
                        Cmd.Parameters.AddRange(objSqlPar);
                        Result = Cmd.ExecuteScalar();

                    }
                    sqlcon.Close();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return Result;
        }

        public DataTable ExecuteTable(string sQuery, SqlParameter[] objSqlPar, CommandType commandType = CommandType.StoredProcedure)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(sConn))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcmd = new SqlCommand(sQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        if (objSqlPar != null)
                            sqlcmd.Parameters.AddRange(objSqlPar);
                        SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                        adpt.Fill(dt);
                    }
                    sqlcon.Close();
                }
            }
            catch (Exception Ex)
            {
                new ErrorLog().WriteLog(Ex);
            }
            return dt;
        }
        public DataSet dsExecuteTable(string sQuery, SqlParameter[] objSqlPar, CommandType commandType = CommandType.StoredProcedure)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(sConn))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcmd = new SqlCommand(sQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        if (objSqlPar != null)
                            sqlcmd.Parameters.AddRange(objSqlPar);
                        SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                        adpt.Fill(ds);
                    }
                    sqlcon.Close();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ds;
        }

    }

}
