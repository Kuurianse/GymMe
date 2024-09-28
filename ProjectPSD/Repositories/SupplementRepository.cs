using ProjectPSD.Factories;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class SupplementRepository
    {
        ProjectDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<MsSupplement> GetSupplements()
        {
            return db.MsSupplements.ToList();
        }

        public int GetLastSupplementID()
        {
            return (from x in db.MsSupplements select x.SupplementID).ToList().LastOrDefault();
        }

        public int GenerateSupplementTypeID()
        {
            SupplementRepository suppRepo = new SupplementRepository();
            int newID = 0;
            int lastID = suppRepo.GetLastSupplementID();

            if (lastID == 0)
            {
                newID = lastID;
            }
            else
            {
                int idNumber = lastID;
                idNumber++;
                newID = idNumber;
            }

            return newID;
        }

        public void doInsertSupplement(String suppName, DateTime suppExpiry, int suppPrice, int suppTypeID)
        {
            MsSupplement msSupplement = new MsSupplement();
            int suppId = GenerateSupplementTypeID();

            MsSupplement msSupp = SupplementFactory.Create(suppId, suppName, suppExpiry, suppPrice, suppTypeID);
            Debug.WriteLine(msSupplement.SupplementID);
            db.MsSupplements.Add(msSupp);
            db.SaveChanges();
        }

        /* 
        public void InsertSupplement(int suppId, String suppName, DateTime suppExpiry, int suppPrice, int suppTypeID)
        {
            MsSupplement msSupp = SupplementFactory.Create(suppId, suppName, suppExpiry, suppPrice, suppTypeID);
            db.MsSupplements.Add(msSupp);
            db.SaveChanges();
        }
        */
        public void RemoveSupplementByID(int id)
        {
            MsSupplement msSupp = db.MsSupplements.Find(id);
            db.MsSupplements.Remove(msSupp); 
            db.SaveChanges();
        }

        public MsSupplement GetSupplementByID(int id)
        {
            MsSupplement msSupp = db.MsSupplements.Find(id);
            return msSupp;
        }

        public void UpdateSupplementByID(int suppId, String suppName, DateTime suppExpiry, int suppPrice, int suppTypeID)
        {
            MsSupplement updateMsSupp = GetSupplementByID(suppId);
            updateMsSupp.SupplementName = suppName;
            updateMsSupp.SupplementExpiryDate = suppExpiry;
            updateMsSupp.SupplementPrice = suppPrice;
            updateMsSupp.SupplementTypeID = suppTypeID;
            db.SaveChanges();
        }
    }
}