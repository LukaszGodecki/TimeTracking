using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracking.Entities
{
    public class TimeTrackingGroup
    {
        #region properties
        public string Guid { get; set; }
        public string Job { get; set; }
        public int JobTypeId { get; set; }
        public int Count { get; set; }
        #endregion
        #region Database columns' names 
        public static string GuidDatabaseColumnName = "Guid";
        public static string JobDatabaseColumnName = "Job";
        public static string JobTypeIdDatabaseColumnName = "JobTypeId";
        public static string CountDatabaseColumnName = "Count";
        #endregion
        #region constructors
        public TimeTrackingGroup()
        {

        }
        #endregion
    }
}
