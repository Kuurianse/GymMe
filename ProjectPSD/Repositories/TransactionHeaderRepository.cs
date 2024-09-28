using ProjectPSD.Factories;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repositories
{
    public class TransactionHeaderRepository
    {
        ProjectDatabaseEntities db = DatabaseSingleton.GetInstance();

        public void UpdateTransactionStatusByID(int transactionId, String status)
        {
            String newStatus = "";
            if (status.Equals("unhandled"))
            {
                newStatus = "handled";
            }
            else if (status.Equals("handled"))
            {
                newStatus = "handled";
            }

            TransactionHeader updateTh = db.TransactionHeaders.Find(transactionId);
            updateTh.Status = newStatus;
            db.SaveChanges();
        }

        public List<TransactionHeader> GetTransactionHeadersByUserId(int userId)
        {
            return db.TransactionHeaders.Where(c => c.UserID == userId).ToList();
        }

        public void ClearAllTransactionHeader()
        {
            db.TransactionHeaders.RemoveRange(db.TransactionHeaders);
            db.SaveChanges();
        }

        public List<TransactionHeader> GetTransactions()
        {
            return db.TransactionHeaders.ToList();
        }

        public int GetLastTransactionID()
        {
            return (from x in db.TransactionHeaders select x.TransactionID ).ToList().LastOrDefault();
        }

        public void InsertTransaction(int transactionId, int userId, DateTime transactionDate, String status)
        {
            TransactionHeader th = TransactionHeaderFactory.Create(transactionId, userId, transactionDate, status);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }

        public void RemoveTransactionByID(int id)
        {
            TransactionHeader th = db.TransactionHeaders.Find(id);
            db.TransactionHeaders.Remove(th);
            db.SaveChanges();
        }

        public TransactionHeader GetTransactionByID(int id)
        {
            TransactionHeader th = db.TransactionHeaders.Find(id);
            return th;
        }

        public void UpdateTransactionByID(int transactionId, int userId, DateTime transactionDate, String status)
        {
            TransactionHeader updateTh = db.TransactionHeaders.Find(transactionId);
            updateTh.UserID = userId;
            updateTh.TransactionDate = transactionDate;
            updateTh.Status = status;
            db.SaveChanges();
        }
    }
}