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
    public class InsertJobTypeCommand : ICommand
    {
        private JobType jobType;
        public static int InsertedID;
        public InsertJobTypeCommand(JobType jobType)
        {
            this.jobType = jobType;
        }
        public void Execute()
        {
            string sqlQuery = "[dbo].[USP_InsertJobType]";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlParameter outputParam = sqlComm.Parameters.Add("@" + JobType.IDDatabaseColumnName, SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;

                sqlComm.Parameters.Add("@" + JobType.NameDatabaseColumnName, SqlDbType.NVarChar).Value = jobType.Name;

                sqlComm.ExecuteNonQuery();
                InsertedID = Convert.ToInt32(outputParam.Value);
            }
        }
    }
}
