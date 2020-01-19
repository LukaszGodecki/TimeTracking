using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.CodeBase.DataLayer;
using TimeTracking.Entities;

namespace TimeTracking.CodeBase.ServiceLayer.Commands
{
    public class InsertTimeTrackigLogCommand : ICommand
    {
        private TimeTrackingLog timeTrackingLog;
        public InsertTimeTrackigLogCommand(TimeTrackingLog timeTrackingLog)
        {
            this.timeTrackingLog = timeTrackingLog;
        }
        public void Execute()
        {
            string sqlQuery = "[dbo].[USP_InsertTimeTrackingLog]";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                sqlComm.Parameters.Add("@" + TimeTrackingLog.GuidDatabaseColumnName, SqlDbType.NVarChar).Value = timeTrackingLog.Guid;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.DescriptionDatabaseColumnName, SqlDbType.NVarChar).Value = timeTrackingLog.Description;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.StartTimeDatabaseColumnName, SqlDbType.DateTime).Value = timeTrackingLog.StartTime;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.StartMethodTimeDatabaseColumnName, SqlDbType.DateTime).Value = timeTrackingLog.StartMethodTime;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.EndTimeDatabaseColumnName, SqlDbType.DateTime).Value = timeTrackingLog.EndTime;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.TotalTimeDatabaseColumnName, SqlDbType.Decimal).Value = timeTrackingLog.TotalTime;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.MethodTimeDatabaseColumnName, SqlDbType.Decimal).Value = timeTrackingLog.MethodTime;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.JobDatabaseColumnName, SqlDbType.NVarChar).Value = timeTrackingLog.Job;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.JobTypeIdDatabaseColumnName, SqlDbType.TinyInt).Value = timeTrackingLog.JobTypeId;

                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
