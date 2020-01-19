using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.CodeBase.ServiceLayer.Commands;
using TimeTracking.Entities;

namespace TimeTracking.CodeBase.ServiceLayer
{
    public static partial class MainService
    {
        #region handleQuery
        public static void handleCommand(ICommand command)
        {
            try
            {
                command.Execute();
            }
            catch (Exception exc)
            {
                //ToDo: implement NLog
            }
        }
        #endregion

        #region Workers
        public static void DeleteWorker(int ID)
        {
            var command = new DeleteWorkerCommand(ID);
            handleCommand(command);
        }
        public static void UpdateWorker(Worker worker)
        {
            var command = new UpdateWorkerCommand(worker);
            handleCommand(command);
        }
        public static int InsertWorker(Worker worker)
        {
            var command = new InsertWorkerCommand(worker);
            handleCommand(command);
            return InsertWorkerCommand.InsertedID;
        }
        #endregion

        #region JobType
        public static void DeleteJobType(int ID)
        {
            var command = new DeleteJobTypeCommand(ID);
            handleCommand(command);
        }
        public static void UpdateJobType(JobType jobType)
        {
            var command = new UpdateJobTypeCommand(jobType);
            handleCommand(command);
        }
        public static int InsertJobType(JobType jobType)
        {
            var command = new InsertJobTypeCommand(jobType);
            handleCommand(command);
            return InsertJobTypeCommand.InsertedID;

            #endregion

        }
        #region TimeTrackingLog
        public static void InsertTimeTrackingLog(TimeTrackingLog timeTrackingLog)
        {
            var command = new InsertTimeTrackigLogCommand(timeTrackingLog);
            handleCommand(command);

        #endregion

        }
    }
}
