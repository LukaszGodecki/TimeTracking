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
        public static JobType GetJobType(SqlDataReader dataFromDatabase)
        {
            JobType jobType = new JobType();


            jobType.ID = dataFromDatabase.HasColumn(JobType.IDDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[JobType.IDDatabaseColumnName]) : 0;
            jobType.Name = dataFromDatabase.HasColumn(JobType.NameDatabaseColumnName) ? dataFromDatabase[JobType.NameDatabaseColumnName].ToString() : "Default";

            return jobType;
        }
        public static TimeTrackingLog GetTimeTrackingLog(SqlDataReader dataFromDatabase)
        {
            TimeTrackingLog timeTrackingLog = new TimeTrackingLog();


            timeTrackingLog.ID = dataFromDatabase.HasColumn(TimeTrackingLog.IDDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[TimeTrackingLog.IDDatabaseColumnName]) : 0;

            timeTrackingLog.Guid = dataFromDatabase.HasColumn(TimeTrackingLog.GuidDatabaseColumnName) ? dataFromDatabase[TimeTrackingLog.GuidDatabaseColumnName].ToString() : "Default";

            timeTrackingLog.Description = dataFromDatabase.HasColumn(TimeTrackingLog.DescriptionDatabaseColumnName) ? dataFromDatabase[TimeTrackingLog.DescriptionDatabaseColumnName].ToString() : "Default";

            timeTrackingLog.StartTime = dataFromDatabase.HasColumn(TimeTrackingLog.StartTimeDatabaseColumnName) ? DateTime.Parse(dataFromDatabase[TimeTrackingLog.StartTimeDatabaseColumnName].ToString()) : new DateTime();

            timeTrackingLog.StartMethodTime = dataFromDatabase.HasColumn(TimeTrackingLog.StartTimeDatabaseColumnName) ? DateTime.Parse(dataFromDatabase[TimeTrackingLog.StartMethodTimeDatabaseColumnName].ToString()) : new DateTime();

            timeTrackingLog.EndTime = dataFromDatabase.HasColumn(TimeTrackingLog.StartTimeDatabaseColumnName) ? DateTime.Parse(dataFromDatabase[TimeTrackingLog.EndTimeDatabaseColumnName].ToString()) : new DateTime();

            timeTrackingLog.TotalTime = dataFromDatabase.HasColumn(TimeTrackingLog.TotalTimeDatabaseColumnName) ? Convert.ToDecimal(dataFromDatabase[TimeTrackingLog.TotalTimeDatabaseColumnName]) : 0;

            timeTrackingLog.MethodTime = dataFromDatabase.HasColumn(TimeTrackingLog.MethodTimeDatabaseColumnName) ? Convert.ToDecimal(dataFromDatabase[TimeTrackingLog.MethodTimeDatabaseColumnName]) : 0;

            timeTrackingLog.Job = dataFromDatabase.HasColumn(TimeTrackingLog.JobDatabaseColumnName) ? dataFromDatabase[TimeTrackingLog.JobDatabaseColumnName].ToString() : "Default";

            timeTrackingLog.JobTypeId = dataFromDatabase.HasColumn(TimeTrackingLog.JobTypeIdDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[TimeTrackingLog.JobTypeIdDatabaseColumnName]) : 0;

            return timeTrackingLog;
        }
        public static TimeTrackingGroup GetTimeTrackingGroup(SqlDataReader dataFromDatabase)
        {
            TimeTrackingGroup timeTrackingGroup = new TimeTrackingGroup();

            timeTrackingGroup.Guid = dataFromDatabase.HasColumn(TimeTrackingGroup.GuidDatabaseColumnName) ? dataFromDatabase[TimeTrackingGroup.GuidDatabaseColumnName].ToString() : "Default";

            timeTrackingGroup.Job = dataFromDatabase.HasColumn(TimeTrackingGroup.JobDatabaseColumnName) ? dataFromDatabase[TimeTrackingGroup.JobDatabaseColumnName].ToString() : "Default";

            timeTrackingGroup.JobTypeId = dataFromDatabase.HasColumn(TimeTrackingGroup.JobTypeIdDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[TimeTrackingGroup.JobTypeIdDatabaseColumnName]) : 0;

            timeTrackingGroup.Count = dataFromDatabase.HasColumn(TimeTrackingGroup.CountDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[TimeTrackingGroup.CountDatabaseColumnName]) : 0;

            return timeTrackingGroup;
        }
    }
}
