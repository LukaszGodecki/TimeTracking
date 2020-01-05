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
    public class UpdateWorkerCommand : ICommand
    {
        private Worker worker;
        public UpdateWorkerCommand(Worker worker)
        {
            this.worker = worker;
        }
        public void Execute()
        {
            string sqlQuery = "[dbo].[USP_UpdateWorker]";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;                
                sqlComm.Parameters.Add("@" + Worker.IDDatabaseColumnName, SqlDbType.Int).Value = worker.ID;
                sqlComm.Parameters.Add("@" + Worker.AgeDatabaseColumnName, SqlDbType.TinyInt).Value = worker.Age;
                sqlComm.Parameters.Add("@" + Worker.NameDatabaseColumnName, SqlDbType.NVarChar).Value = worker.Name;
                sqlComm.Parameters.Add("@" + Worker.SurnameDatabaseColumnName, SqlDbType.NVarChar).Value = worker.Surname;
                sqlComm.Parameters.Add("@" + Worker.GenderDatabaseColumnName, SqlDbType.Bit).Value = worker.Gender;
                sqlComm.Parameters.Add("@" + Worker.JobDescriptionDatabaseColumnName, SqlDbType.NVarChar).Value = worker.JobDescription;
                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
