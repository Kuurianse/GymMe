using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class DatabaseSingleton
    {
        private static ProjectDatabaseEntities db = null;

        public static ProjectDatabaseEntities GetInstance()
        {
            if (db == null)
            {
                db = new ProjectDatabaseEntities();
            }
            return db;
        }
    }
}