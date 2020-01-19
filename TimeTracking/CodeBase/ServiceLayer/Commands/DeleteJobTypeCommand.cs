﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.CodeBase.DataLayer;
using TimeTracking.Entities;

namespace TimeTracking.CodeBase.ServiceLayer.Commands
{
    public class DeleteJobTypeCommand : ICommand
    {
        private int ID;
        public DeleteJobTypeCommand(int ID)
        {
            this.ID = ID;
        }
        public void Execute()
        {
            string sqlQuery = "[dbo].[USP_DeleteJobType]";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.Add("@" + JobType.IDDatabaseColumnName, SqlDbType.Int).Value = ID;
                sqlComm.ExecuteNonQuery();
            }

        }
    }
}
