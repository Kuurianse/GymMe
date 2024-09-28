using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int TransactionId, int SuppId, int Quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = TransactionId;
            td.SupplementID = SuppId;
            td.Quantity = Quantity;
            return td;
        }
    }
}