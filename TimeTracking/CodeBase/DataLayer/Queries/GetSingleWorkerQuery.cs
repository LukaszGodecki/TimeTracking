using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.CodeBase.ServiceLayer;
using TimeTracking.Entities;

namespace TimeTracking.CodeBase.DataLayer.Queries
{
    public class GetSingleWorkerQuery : IQuery<Worker>
    {
        private int ID;
        public GetSingleWorkerQuery(int ID)
        {
            this.ID = ID;
        }
        public Worker Execute()
        {
            string sqlQuery = "[dbo].[USP_SelectSingleWorker]";
            Worker worker = new Worker();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.Add("@" + Worker.IDDatabaseColumnName, SqlDbType.Int).Value = ID;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        worker = MainService.GetWorker(r);
                    }
                }
            }
            return worker;
        }
    }
}
