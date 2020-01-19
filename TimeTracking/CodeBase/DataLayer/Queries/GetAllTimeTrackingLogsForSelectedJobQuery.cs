using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TimeTracking.Entities;
using TimeTracking.CodeBase.ServiceLayer;

namespace TimeTracking.CodeBase.DataLayer.Queries
{
    public class GetAllTimeTrackingLogsForSelectedJobQuery : IQuery<List<TimeTrackingLog>>
    {
        private string job;
        public GetAllTimeTrackingLogsForSelectedJobQuery(string job)
        {
            this.job = job;
        }
        public List<TimeTrackingLog> Execute()
        {
            string sqlQuery = "[dbo].[USP_SelectAllTimeTrackingLogsForSelectedJob]";
            List<TimeTrackingLog> timeTrackingLogs = new List<TimeTrackingLog>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.Add("@" + TimeTrackingLog.JobDatabaseColumnName, SqlDbType.NVarChar).Value = job;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        timeTrackingLogs.Add(MainService.GetTimeTrackingLog(r));
                    }
                }
            }
            return timeTrackingLogs;
        }
    }    
}

