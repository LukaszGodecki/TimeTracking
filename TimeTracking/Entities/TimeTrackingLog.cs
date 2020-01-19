using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracking.Entities
{
    public class TimeTrackingLog
    {
        #region properties

        public int ID { get; set; }
        public string Guid { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StartMethodTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalTime { get; set; }
        public decimal MethodTime { get; set; }
        public string Job { get; set; }
        public int JobTypeId { get; set; }

        #endregion
        #region Database columns' names 
        public static string IDDatabaseColumnName = "ID";
        public static string GuidDatabaseColumnName = "Guid";
        public static string DescriptionDatabaseColumnName = "Description";
        public static string StartTimeDatabaseColumnName = "StartTime";
        public static string StartMethodTimeDatabaseColumnName = "StartMethodTime";
        public static string EndTimeDatabaseColumnName = "EndTime";
        public static string TotalTimeDatabaseColumnName = "TotalTime";
        public static string MethodTimeDatabaseColumnName = "MethodTime";
        public static string JobDatabaseColumnName = "Job";
        public static string JobTypeIdDatabaseColumnName = "JobTypeId";


        #endregion
        #region constructors
        public TimeTrackingLog()
        {

        }
        #endregion
    }
}
