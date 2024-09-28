using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class SupplementTypeRepository
    {
        ProjectDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<String> GetSupplementTypeNames()
        {
            return (from x in db.MsSupplementTypes select x.SupplementTypeName).ToList();
        }

        public int GetSupplementTypeIDByName(String name)
        {
            return (from x in db.MsSupplementTypes where x.SupplementTypeName.Equals(name) select x.SupplementTypeID).FirstOrDefault();
        }

        public String GetSupplementTypeNameByID(int id)
        {
            return (from x in db.MsSupplementTypes where x.SupplementTypeID.Equals(id) select x.SupplementTypeName).FirstOrDefault();
        }
    }
}