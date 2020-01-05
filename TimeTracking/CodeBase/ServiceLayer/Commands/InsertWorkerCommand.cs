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
    public class InsertWorkerCommand : ICommand
    {
        private Worker worker;
        public static int InsertedID;
        public InsertWorkerCommand(Worker worker)
        {
            this.worker = worker;
        }
        public void Execute()
        {
            string sqlQuery = "[dbo].[USP_InsertWorker]";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlParameter outputParam = sqlComm.Parameters.Add("@" + Worker.IDDatabaseColumnName, SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;

                sqlComm.Parameters.Add("@" + Worker.AgeDatabaseColumnName, SqlDbType.TinyInt).Value = worker.Age;
                sqlComm.Parameters.Add("@" + Worker.NameDatabaseColumnName, SqlDbType.NVarChar).Value = worker.Name;
                sqlComm.Parameters.Add("@" + Worker.SurnameDatabaseColumnName, SqlDbType.NVarChar).Value = worker.Surname;
                sqlComm.Parameters.Add("@" + Worker.GenderDatabaseColumnName, SqlDbType.Bit).Value = worker.Gender;
                sqlComm.Parameters.Add("@" + Worker.JobDescriptionDatabaseColumnName, SqlDbType.NVarChar).Value = worker.JobDescription;

                sqlComm.ExecuteNonQuery();
                InsertedID = Convert.ToInt32(outputParam.Value);
            }
        }
    }
}
