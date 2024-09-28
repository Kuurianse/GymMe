using ProjectPSD.Hadler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class SupplementController
    {
        
        public static string doInsertSupplement(String suppName, DateTime suppExpiry, int suppPrice, int suppTypeID)
        {
            if (!suppName.Contains("Supplement")){
                return "Must contains ‘Supplement’";
            }
            else if(suppExpiry <= DateTime.Now)
            {
                return "Expiry Date must be greater than today's date";
            }
            else if(suppPrice < 3000)
            {
                return "Price must be at least 3000";
            }
            else if(suppTypeID == 0)
            {
                return "Cannot be empty";
            }
            else
            {
                SupplementHandler suppHandler = new SupplementHandler();
                suppHandler.doInsertSupplement(suppName, suppExpiry, suppPrice, suppTypeID);
                return "Insert Success";
            }
        }
        

        /*
        public static string doInsertSupplement(String suppName, DateTime suppExpiry, int suppPrice, int suppTypeID)
        {
            if (!suppName.Contains("Supplement") || suppExpiry <= DateTime.Now || suppPrice < 3000 || suppTypeID == 0)
            {
                if (!suppName.Contains("Supplement")) return "Name must contain 'Supplement'. ";
                if (suppExpiry <= DateTime.Now) return "Expiry Date must be greater than today's date. ";
                if (suppPrice < 3000) return "Price must be at least 3000. ";
                if (suppTypeID == 0) return "Type ID cannot be empty. ";
            }

            try
            {
                SupplementHandler suppHandler = new SupplementHandler();
                suppHandler.doInsertSupplement(suppName, suppExpiry, suppPrice, suppTypeID);
                return "Insert Success";
            }
            catch (Exception ex)
            {
                // Tangani kesalahan yang terjadi saat insert ke database
                return "Insert Failed: " + ex.Message;
            }
        }
        */
    }
}