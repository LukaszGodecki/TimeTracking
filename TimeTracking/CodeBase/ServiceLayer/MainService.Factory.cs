using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.CodeBase.ServiceLayer.Tools;
using TimeTracking.Entities;

namespace TimeTracking.CodeBase.ServiceLayer
{
    public static partial class MainService
    {
        public static Worker GetWorker(SqlDataReader dataFromDatabase)
        {
            Worker worker = new Worker();

            worker.ID = dataFromDatabase.HasColumn(Worker.IDDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[Worker.IDDatabaseColumnName]) : 0;
            worker.Age = dataFromDatabase.HasColumn(Worker.AgeDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[Worker.AgeDatabaseColumnName]) : 0;
            worker.Name = dataFromDatabase.HasColumn(Worker.NameDatabaseColumnName) ? dataFromDatabase[Worker.NameDatabaseColumnName].ToString() : "Default";
            worker.Surname = dataFromDatabase.HasColumn(Worker.SurnameDatabaseColumnName) ? dataFromDatabase[Worker.SurnameDatabaseColumnName].ToString() : "Default";
            worker.JobDescription = dataFromDatabase.HasColumn(Worker.JobDescriptionDatabaseColumnName) ? dataFromDatabase[Worker.JobDescriptionDatabaseColumnName].ToString() : "Default";
            worker.Gender = dataFromDatabase.HasColumn(Worker.GenderDatabaseColumnName) ? (bool)dataFromDatabase[Worker.GenderDatabaseColumnName] : false;

            return worker;
        }
    }
}
