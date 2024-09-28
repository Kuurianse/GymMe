using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factories
{
    public class CartFactory
    {
        public static MsCart Create(int cartId, int userId, int suppId, int quantity)
        {
            MsCart msCart = new MsCart();
            msCart.CartID = cartId;
            msCart.UserID = userId;
            msCart.SupplementID = suppId;
            msCart.Quantity = quantity;
            return msCart;
        }
    }
}