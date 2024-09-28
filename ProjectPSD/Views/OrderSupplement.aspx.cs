using ProjectPSD.Model;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class OrderSupplement1 : System.Web.UI.Page
    {
        public List<MsSupplement> supplements = null;
        public List<MsCart> carts = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null && Request.Cookies["User_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                UserRepository userRepo = new UserRepository();
                MsUser userSession = new MsUser();

                if (Session["User"] == null)
                {
                    int userId = Convert.ToInt32(Request.Cookies["User_cookie"].Value);
                    userSession = userRepo.GetUserByID(userId);
                    Session["User"] = userSession;
                }
                else
                {
                    userSession = (MsUser)Session["User"];
                }
            }

            SupplementRepository suppRepo = new SupplementRepository();

            if (IsPostBack == false)
            {
                supplements = suppRepo.GetSupplements();
                orderSupplementGV.DataSource = supplements;
                orderSupplementGV.DataBind();
            }
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            CartRepository cartRepo = new CartRepository();
            cartRepo.ClearAllCart();
            msgLbl.Text = "Clear Cart Success";

            carts = cartRepo.GetCarts();
            cartGV.DataSource = carts;
            cartGV.DataBind();
        }

        /*
        private int GenerateTransactionID()
        {
            TransactionHeaderRepository thRepo = new TransactionHeaderRepository();
            int newID = 0;
            int lastID = thRepo.GetLastTransactionID();

            if (lastID == 0)
            {
                newID = 1;
            }
            else
            {
                int idNumber = lastID;
                idNumber++;
                newID = idNumber;
            }
            return newID;
        }
        */

        private int GenerateTransactionID()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            int timestamp = (int)DateTime.Now.Ticks;
            return Math.Abs(timestamp + randomNumber); // Menggunakan Math.Abs untuk memastikan positif
        }

        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            TransactionHeaderRepository thRepo = new TransactionHeaderRepository();
            TransactionDetailRepository tdRepo = new TransactionDetailRepository();
            CartRepository cartRepo = new CartRepository();

            int transactionId = GenerateTransactionID();
            MsUser msUser = (MsUser)Session["User"];
            int userId = msUser.UserID;
            DateTime dateTime = DateTime.Now;
            String status = "unhandled";

            // thRepo.InsertTransaction(transactionId, userId, dateTime, status);

            // ... (inisialisasi repositori dan data lainnya) ...

            thRepo.InsertTransaction(transactionId, userId, dateTime, status);

            List<MsCart> cartsToInsert = cartRepo.GetCartsByUserId(userId);

            // Buat List untuk menampung TransactionDetail
            List<TransactionDetail> transactionDetails = new List<TransactionDetail>();

            foreach (var cartItem in cartsToInsert)
            {
                // Buat objek TransactionDetail baru untuk setiap item cart
                TransactionDetail detail = new TransactionDetail
                {
                    TransactionID = transactionId,
                    SupplementID = cartItem.SupplementID,
                    Quantity = cartItem.Quantity
                };

                transactionDetails.Add(detail);
            }

            // Simpan semua TransactionDetail ke database
            tdRepo.InsertTransactionDetails(transactionDetails); // Asumsikan fungsi ini menerima List<TransactionDetail>

            // ... (kode lainnya seperti sebelumnya) ...

            // ProjectDatabaseEntities db = DatabaseSingleton.GetInstance();
            /**/
            /*
            List<MsCart> newCarts = cartRepo.GetCartsByUserId(userId);
            foreach (var cartItem in newCarts)
            {
                tdRepo.InsertTransactionDetails(transactionId, cartItem.SupplementID, cartItem.Quantity);
            }
            */
            // MsCart msCart = cartRepo.GetCartsByUserIdONLYONE(userId);
            // tdRepo.InsertTransactionDetails(transactionId, msCart.SupplementID, msCart.Quantity);

            msgLbl.Text = "CheckOut Success";
            cartRepo.ClearAllCart();

            carts = cartRepo.GetCarts();
            cartGV.DataSource = carts;
            cartGV.DataBind();
        }

        /*
        private int GenerateCartID()
        {
            CartRepository cartRepo = new CartRepository();

            int newID = 0;
            int lastID = cartRepo.GetLastCartID();

            if(lastID == 0)
            {
                newID = 1;
            }
            else
            {
                int idNumber = lastID;
                idNumber++;
                newID = idNumber;
            }
            return newID;
        }
        */

        private int GenerateCartID()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            int timestamp = (int)DateTime.Now.Ticks;
            return Math.Abs(timestamp + randomNumber); // Menggunakan Math.Abs untuk memastikan positif
        }

        protected void orderSupplementGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            MsUser msUser = (MsUser)Session["User"];
            // Mendapatkan TextBox dari sel yang dipilih
            TextBox quantityTextBox = (TextBox)orderSupplementGV.SelectedRow.Cells[5].FindControl("quantityTB");
            // Mengambil nilai dari TextBox
            string quantityText = quantityTextBox.Text;
            int quantity = 0;


            if (int.TryParse(quantityText, out quantity) && quantity > 0)
            {
                string id = orderSupplementGV.SelectedRow.Cells[0].Text.ToString();
                CartRepository cartRepo = new CartRepository();

                int cartId = GenerateCartID();
                int userId = msUser.UserID;
                int suppId = Convert.ToInt32(id);

                cartRepo.InsertCart(cartId, userId, suppId, quantity);

                // msgLbl.Text = "id: " + id + " quantity: " + quantity;
                msgLbl.Text = "Insert Cart Success";

                carts = cartRepo.GetCarts();
                cartGV.DataSource = carts;
                cartGV.DataBind();
            }
            else
            {
                msgLbl.Text = "Quantity harus berupa angka lebih besar dari 0.";
            }
            quantityTextBox.Text = "";
        }
    }
 }