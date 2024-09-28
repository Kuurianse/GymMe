using ProjectPSD.Factories;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectPSD.Repositories
{
    public class CartRepository
    {
        ProjectDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<MsCart> GetCartsByUserId(int userId)
        {
            return db.MsCarts.Where(c => c.UserID == userId).ToList();
        }

        public MsCart GetCartsByUserIdONLYONE(int userId)
        {
            return (from x in db.MsCarts where x.UserID.Equals(userId) select x).FirstOrDefault();
        }

        public List<MsCart> GetCarts()
        {
            return db.MsCarts.ToList();
        }

        public int GetLastCartID()
        {
            return (from x in db.MsCarts select x.CartID).ToList().LastOrDefault();

        }

        public void InsertCart(int cartId, int userId, int suppId, int quantity)
        {
            MsCart msCart = CartFactory.Create(cartId, userId, suppId, quantity);
            db.MsCarts.Add(msCart);
            db.SaveChanges();
        }

        public void RemoveCartByID(int cartId)
        {
            MsCart msCart = db.MsCarts.Find(cartId);
            db.MsCarts.Remove(msCart);
            db.SaveChanges();
        }

        public void UpdateCartByID(int cartId, int userId, int suppId, int quantity)
        {
            MsCart updateMsCart = db.MsCarts.Find(cartId);
            updateMsCart.CartID = cartId;
            updateMsCart.UserID = userId;
            updateMsCart.SupplementID = suppId;
            updateMsCart.Quantity = quantity;
            db.SaveChanges();
        }

        public void ClearAllCart()
        {
            db.MsCarts.RemoveRange(db.MsCarts); // Remove all entries
            db.SaveChanges();
        }
    }
}