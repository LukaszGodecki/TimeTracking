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
    public class GetAllJobTypesQuery : IQuery<List<JobType>>
    {
        public List<JobType> Execute()
        {
            string sqlQuery = "[dbo].[USP_SelectAllJobTypes]";
            List<JobType> jobTypes = new List<JobType>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        jobTypes.Add(MainService.GetJobType(r));
                    }
                }
            }
            return jobTypes;
        }
    }
}
