using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.SupportData
{
    public class RoleService
    {
        SQLServerHandler sQLServerHandler = new SQLServerHandler();
        public DataTable GetRoles(int roleId = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@RoleId", roleId) };
                return sQLServerHandler.ExecuteTable("[support].[sp_GetAllRoles]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);

            }
            return dataTable;
        }
        public void AddAndEditRoles(int reoleId, string roleName)
        {
            try
            {
                SqlParameter[] parameters = {
                new SqlParameter("@RoleId", reoleId),
                new SqlParameter("@RoleName", roleName),
                new SqlParameter("@CreatedBy",1),
                    new SqlParameter("@ModifiedBy",1)
                     };
                sQLServerHandler.ExecuteNonQuery("[support].[sp_InsertAndUpdateRole]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        public void DeleteRole(int roleId)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("RoleId", roleId),
                new SqlParameter("ModifiedBy",1)};
                sQLServerHandler.ExecuteNonQuery("[support].[sp_DeleteRole]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }

    
}
