using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TimeTracking.Entities;
using TimeTracking.CodeBase.ServiceLayer;
using System.Data.SqlTypes;
using TimeTracking.CodeBase.ServiceLayer.Tools;

namespace TimeTracking.CodeBase.DataLayer.Queries
{
    public class GetTimeTrackingGroupsQuery : IQuery<List<TimeTrackingGroup>>
    {
        private string guid; 
        private string job;
        private int jobTypeId;
        public GetTimeTrackingGroupsQuery(string guid, string job, int jobTypeId)
        {
            this.guid = guid;
            this.job = job;
            this.jobTypeId = jobTypeId;            
        }
        public List<TimeTrackingGroup> Execute()
        {
            string sqlQuery = "[dbo].[USP_SelectTimeTrackingGroupsLogs]";
            List<TimeTrackingGroup> timeTrackingGroups = new List<TimeTrackingGroup>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;               
                sqlComm.Parameters.Add("@" + TimeTrackingGroup.GuidDatabaseColumnName, SqlDbType.NVarChar).Value = guid.DbNullIfNull();
                sqlComm.Parameters.Add("@" + TimeTrackingGroup.JobDatabaseColumnName, SqlDbType.NVarChar).Value = job.DbNullIfNull();
                sqlComm.Parameters.Add("@" + TimeTrackingGroup.JobTypeIdDatabaseColumnName, SqlDbType.Int).Value = jobTypeId;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        timeTrackingGroups.Add(MainService.GetTimeTrackingGroup(r));
                    }
                }
            }
            return timeTrackingGroups;
        }
    }
}
