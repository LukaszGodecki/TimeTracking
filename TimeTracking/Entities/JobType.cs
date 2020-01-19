using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracking.Entities
{
    public class JobType
    {
        #region properties
        public int ID { get; set; }
        public string Name { get; set; }
        #endregion

        #region Database columns' names 
        public static string IDDatabaseColumnName = "ID";
        public static string NameDatabaseColumnName = "Name";
        #endregion
        #region constructors
        public JobType()
        {

        }
        #endregion
    }
}
