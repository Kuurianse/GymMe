using ProjectPSD.Model;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Hadler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetTransactions()
        {
            TransactionHeaderRepository thRepo = new TransactionHeaderRepository();
            return thRepo.GetTransactions();
        }
    }
}