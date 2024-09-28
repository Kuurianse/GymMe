using ProjectPSD.Factories;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class TransactionDetailRepository
    {
        ProjectDatabaseEntities db = DatabaseSingleton.GetInstance();
        // ProjectDatabaseEntities db = new ProjectDatabaseEntities

        public List<TransactionDetail> GetTransactionDetailsByTransactionId(int transactionID)
        {
            return db.TransactionDetails.Where(c => c.TransactionID == transactionID).ToList();
        }

        public void InsertTransactionDetails(List<TransactionDetail> details)
        {
            using (var context = new ProjectDatabaseEntities()) // Ganti dengan DbContext Anda
            {
                context.TransactionDetails.AddRange(details);
                context.SaveChanges();
            }
        }

        public void ClearAllTransactionDetail()
        {
            db.TransactionDetails.RemoveRange(db.TransactionDetails);
            db.SaveChanges();
        }

        public List<TransactionDetail> GetTransactionDetails()
        {
            return db.TransactionDetails.ToList();
        }

        public int GetLastTransactionDetailID()
        {
            return (from x in db.TransactionDetails select x.TransactionID).ToList().LastOrDefault();
        }

        public void InsertTransactionDetails(int TransactionId, int SuppId, int Quantity)
        {
            TransactionDetail td = TransactionDetailFactory.Create(TransactionId, SuppId, Quantity);
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public void RemoveTransactionDetailByID(int id)
        {
            TransactionDetail td = db.TransactionDetails.Find(id);
            db.TransactionDetails.Remove(td);
            db.SaveChanges();
        }

        public TransactionDetail GetTransactionDetailByID(int id)
        {
            TransactionDetail td = db.TransactionDetails.Find(id);
            return td;
        }

        public void UpdateTransactionDetailByID(int TransactionId, int SuppId, int Quantity)
        {
            TransactionDetail updateTd = db.TransactionDetails.Find(TransactionId);
            updateTd.TransactionID = TransactionId;
            updateTd.SupplementID = SuppId;
            updateTd.Quantity = Quantity;
            db.SaveChanges();
        }
        
    }
}