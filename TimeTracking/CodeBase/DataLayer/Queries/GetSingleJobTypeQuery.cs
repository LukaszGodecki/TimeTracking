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
    public class GetSingleJobTypeQuery : IQuery<JobType>
    {
        private int ID;
        public GetSingleJobTypeQuery(int ID)
        {
            this.ID = ID;
        }
        public JobType Execute()
        {
            string sqlQuery = "[dbo].[USP_SelectSingleJobType]";
            JobType jobType = new JobType();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.Add("@" + JobType.IDDatabaseColumnName, SqlDbType.Int).Value = ID;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        jobType = MainService.GetJobType(r);
                    }
                }
            }
            return jobType;
        }
    }
    }