using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.Entities;
using TimeTracking.CodeBase.ServiceLayer;

namespace TimeTracking.CodeBase.DataLayer.Queries
{
    public class GetAllWorkersQuery : IQuery<List<Worker>>
    {
        public List<Worker> Execute()
        {
            string sqlQuery = "[dbo].[USP_SelectAllWorkers]";
            List<Worker> workers = new List<Worker>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while(r.Read())
                    {
                        workers.Add(MainService.GetWorker(r));
                    }
                }
            }
            return workers;
        }
    }
}
