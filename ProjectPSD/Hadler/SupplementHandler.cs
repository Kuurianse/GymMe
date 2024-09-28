using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace ProjectPSD.Hadler
{
    public class SupplementHandler
    {
        public void doInsertSupplement(string suppName, DateTime suppExpiry, int suppPrice, int suppTypeID)
        {
            SupplementRepository suppRepo = new SupplementRepository();
            suppRepo.doInsertSupplement(suppName, suppExpiry, suppPrice, suppTypeID);
        }
    }
}