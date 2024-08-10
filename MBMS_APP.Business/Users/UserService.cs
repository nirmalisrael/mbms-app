using MBMS_APP.Business.Models;
using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.Users
{
    public class UserService
    {
        SQLServerHandler sQLServerHandler = new SQLServerHandler();


        public void SaveOrUpdateUserDetails(User user)
        {
            try
            {
                SqlParameter[] objSqlPar =
                {
                   new SqlParameter("@UserId", user.UserId),
                   new SqlParameter("@FirstName", user.FirstName),
                   new SqlParameter("@LastName",user.LastName),
                   new SqlParameter("@DateOfBirth", user.DateOfBirth),
                   new SqlParameter("@Gender", user.Gender),
                   new SqlParameter("@Username",user.Email ),
                   new SqlParameter("@PhoneNumber",user.PhoneNumber),
                   new SqlParameter("@AadharNumber",user.AadharNumber),
                   new SqlParameter("@Password",user.Password),
                   new SqlParameter("@Address",user.Address),
                   new SqlParameter("@IsHostel",user.IsHostel),
                   new SqlParameter("@OrganizationId", user.OrganizationId),
                   new SqlParameter("@RoleId",user.RoleId),
                   new SqlParameter("@Salary",user.Salary),
                   new SqlParameter("@CreatedBy", 1),
                   new SqlParameter("@IsActive",1),
                   new SqlParameter("ModifiedBy",1),
                   new SqlParameter("@IsStaffMember",user.IsStaffMember)
                };
                sQLServerHandler.ExecuteNonQuery("[mbms].[sp_InsertAndUpdateUserDetails]", objSqlPar);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public DataTable GetStaffAndAdmin(int userId = 0, int roleId = 1)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@RoleId", roleId)};

                dataTable = sQLServerHandler.ExecuteTable("[mbms].[sp_GetStaffAndAdmin]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }

        public DataTable GetUserDetails(int userId = 0, int roleId = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@RoleId", roleId),
                    new SqlParameter("@UserId",userId)};
                dataTable = sQLServerHandler.ExecuteTable("[mbms].[sp_GetUserDetails]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }

        public int DeleteUserDetails(int userId)
        {
            int result = 0;
            try
            {
                SqlParameter[] param = { new SqlParameter("@UserId", userId),
                new SqlParameter("@ModifiedBy",1)};
               result = sQLServerHandler.ExecuteNonQuery("[mbms].[sp_DeleteUserDetails]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return result;
        }

        public DataSet GetRolesAndOrganization()
        {
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = sQLServerHandler.dsExecuteTable("[support].[sp_GetRolesAndOrganizations]", null);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataSet;
        }

        public DataTable GetUsersByStatus(int status, int roleId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@Status", status),
                    new SqlParameter("@RoleId", roleId)};
                dataTable = sQLServerHandler.ExecuteTable("[mbms].[sp_GetUsersByStatus]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }

        public bool CheckUsernameExists(string username, int userId = 0)
        {
            bool usernameExists = false;
            try
            {
                SqlParameter[] param = { new SqlParameter("@Username", username), new SqlParameter("@UserId", userId) };
                DataTable dataTable = sQLServerHandler.ExecuteTable("[mbms].[sp_CheckUsernameExists]", param);

                if (ConversionHelper.ToInt32(dataTable.Rows[0][0]) > 0)
                {
                    usernameExists = Convert.ToBoolean(dataTable.Rows[0]["UsernameExists"]);
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return usernameExists;
        }

        public void UpdateUserStatus(int isActive, int userId)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@UserId", userId),
            new SqlParameter("@IsActive", isActive)
                };

                sQLServerHandler.ExecuteNonQuery("[mbms].[sp_UpdateUserStatus]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }
}
