﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.CodeBase.DataLayer.Queries;
using TimeTracking.Entities;

namespace TimeTracking.CodeBase.ServiceLayer
{
    public static partial class MainService
    {
        #region handleQuery
        public static T handleQuery<T>(IQuery<T> query)
        {
            try
            {
                return query.Execute();
            }
            catch (Exception exc)
            {
                //ToDo: implement NLog
                return default(T);
            }
        }
        #endregion

        #region Workers
        public static List<Worker> GetAllWorkers()
        {
            var query = new GetAllWorkersQuery();
            return handleQuery(query);
        }
        public static Worker GetSingleWorker(int ID)
        {
            var query = new GetSingleWorkerQuery(ID);
            return handleQuery(query);
        }
        #endregion
    }
}
