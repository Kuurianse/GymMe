using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factories
{
    public class SupplementFactory
    {
        public static MsSupplement Create(int suppId, String suppName, DateTime suppExpiry, int suppPrice, int suppTypeID)
        {
            MsSupplement msSupp = new MsSupplement();
            msSupp.SupplementID = suppId;
            msSupp.SupplementName = suppName;
            msSupp.SupplementExpiryDate = suppExpiry;
            msSupp.SupplementPrice = suppPrice;
            msSupp.SupplementTypeID = suppTypeID;
            return msSupp;
        }
    }
}