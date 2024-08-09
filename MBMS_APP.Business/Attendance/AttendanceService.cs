using MBMS_APP.DataAccess;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MBMS_APP.Business.Attendance
{
    public class AttendanceService
    {
        SQLServerHandler sqlServerHandler = new SQLServerHandler();
        public DataTable GetAttendance(DateTime date)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param = { new SqlParameter("@AttendanceDate", date) };
                dataTable = sqlServerHandler.ExecuteTable("[mbms].[sp_GetAttendanceDetails]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);

            }
            return dataTable;
        }
        public void EditAttendanceDetails(string userIdList, DateTime date, string isPresentList)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@ActionId", 2),
                    new SqlParameter("@UserIdList", userIdList),
                    new SqlParameter("@Date", date),
                    new SqlParameter("@IsPresentList", isPresentList),
                    new SqlParameter("@CreatedBy", 1)
                };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_AttendanceForMembers]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public void TakeAttendanceForMembers(string userIdList, DateTime date, string isPresentList)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@ActionId", 1),
                    new SqlParameter("@UserIdList", userIdList),
                    new SqlParameter("@Date", date),
                    new SqlParameter("@IsPresentList", isPresentList),
                    new SqlParameter("@CreatedBy", 1)
                 };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_AttendanceForMembers]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        public DataSet GetTodayAttendance(DateTime date, int attendance =0)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlParameter[] param = { new SqlParameter("@AttendanceId", attendance),
                new SqlParameter("@Date", date)};
                dataSet = sqlServerHandler.dsExecuteTable("[mbms].[sp_GetAttendanceByDate]", param);

            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
           return dataSet;
        }

        public void InsertLeaveDetails(string userIdList, DateTime fromDate, DateTime toDate)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@UserIdList", userIdList),
                    new SqlParameter("ActionId", 1),
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate),
                    new SqlParameter("@CreatedBy", 1)
                };
                sqlServerHandler.ExecuteNonQuery("[mbms].[sp_LeaveDetails]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        public DataTable GetLeaveDetails(int leaveID,DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@LeaveId",leaveID),
                    new SqlParameter("@FromDate",fromDate),
                    new SqlParameter("@ToDate",toDate)
                };
                dataTable = sqlServerHandler.ExecuteTable("[mbms].[sp_GetLeaveDetails]", param);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return dataTable;
        }

        public void UpdateLeaveDetail(int leaveId,DateTime fromDate,DateTime toDate)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@LeaveId",leaveId),
                    new SqlParameter("@FromDate",fromDate),
                    new SqlParameter("@ToDate",toDate),
                    new SqlParameter("RoleId",1)
                };
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
    }
}
