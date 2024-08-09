using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.SupportData
{
    public class OrganizationService
    {
        SQLServerHandler sQLServerHandler=new SQLServerHandler();
        public DataTable GetOrganization(int organizationId = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@OrganizationId", organizationId) };
                return sQLServerHandler.ExecuteTable("[support].[sp_GetAllOrganization]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }
        public void AddAndEditOrganization(int organizationId, string organizationName)
        {
            try
            {
                SqlParameter[] parameters = {
                new SqlParameter("@OrganizationId", organizationId),
                new SqlParameter("@OrganizationName", organizationName),
                new SqlParameter("@CreatedBy",1),
                new SqlParameter("ModifiedBy",1)
                     };
                sQLServerHandler.ExecuteNonQuery("[support].[sp_InsertAndUpdateOrganization]", parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        public void DeleteOrganization(int organizationId)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("OrganizationId", organizationId),
                new SqlParameter("ModifiedBy",1)};
                sQLServerHandler.ExecuteNonQuery("[support].[sp_DeleteOrganization]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }

        }
    }
}
