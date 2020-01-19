using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracking.Entities
{
    public class Worker
    {
        #region properties
        public int ID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }        
        public string Surname { get; set; }
        public bool Gender { get; set; }
        public string JobDescription { get; set; }
        #endregion
        #region Database columns' names 
        public static string IDDatabaseColumnName = "ID";
        public static string AgeDatabaseColumnName = "Age";
        public static string NameDatabaseColumnName = "Name";
        public static string SurnameDatabaseColumnName = "Surname";
        public static string GenderDatabaseColumnName = "Gender";
        public static string JobDescriptionDatabaseColumnName = "JobDescription";
        #endregion
        #region constructors
        public Worker()
        {

        }
        #endregion
    }
}
