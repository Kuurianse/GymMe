﻿using ProjectPSD.Controller;
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
    public partial class ProfileAdmin : System.Web.UI.Page
    {
        // public List<MsUser> users = null;
        public MsUser users = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            UserRepository userRepo = new UserRepository();

            if (Session["IsAdmin"] == null && Request.Cookies["Admin_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                MsUser userSession = new MsUser();

                if (Session["IsAdmin"] == null)
                {
                    int userId = Convert.ToInt32(Request.Cookies["Admin_cookie"].Value);
                    userSession = userRepo.GetUserByID(userId);
                    Session["IsAdmin"] = userSession;
                }
                else
                {
                    userSession = (MsUser)Session["IsAdmin"];
                }
            }


            if (IsPostBack == false)
            {
                MsUser msUser = (MsUser)Session["IsAdmin"];
                int userId = msUser.UserID;

                /*
                var users = userRepo.GetUserByID(userId);
                DetailsViewProfile.DataSource = new List<object> { users };
                DetailsViewProfile.DataBind();

                users = (List<MsUser>)Session["User"]; // Ambil dari Session
                DetailsViewProfile.DataSource = new List<object> { users };
                DetailsViewProfile.DataBind();
                */
                users = userRepo.GetUserByID(userId);
                DetailsViewProfile.DataSource = new List<MsUser> { users };
                DetailsViewProfile.DataBind();

                MsUser updateUser = userRepo.GetUserByID(userId);

                if (updateUser != null)
                {
                    usernameTB.Text = updateUser.UserName;
                    useremailTB.Text = updateUser.UserEmail;

                    string tempGender = updateUser.UserGender;
                    int gender = 0;

                    if (tempGender.Equals("Male"))
                    {
                        gender = 0;
                    }
                    else if (tempGender.Equals("Female"))
                    {
                        gender = 1;
                    }
                    radioGender.SelectedIndex = gender;
                    dobCalendar.SelectedDate = updateUser.UserDOB;
                }
                else
                {
                    Response.Redirect("~/Views/HomeAdmin.aspx");
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();

            MsUser msUser = (MsUser)Session["IsAdmin"];

            int updateUserID = msUser.UserID;
            string username = usernameTB.Text;
            string email = useremailTB.Text;
            int radio = radioGender.SelectedIndex;
            DateTime dob = dobCalendar.SelectedDate;

            Msg.Text = UserController.UpdateProfile(updateUserID, username, email, radio, dob);

            var userData = userRepo.GetUserByID(updateUserID);
            DetailsViewProfile.DataSource = new List<object> { userData };
            DetailsViewProfile.DataBind();

            /*
            users = userRepo.GetUserByID(updateUserID);
            DetailsViewProfile.DataSource = users;
            DetailsViewProfile.DataBind();

            users = (List<MsUser>)Session["User"]; // Ambil dari Session
            DetailsViewProfile.DataSource = new List<object> { users };
            DetailsViewProfile.DataBind();
            */

            users = userRepo.GetUserByID(updateUserID);
            DetailsViewProfile.DataSource = new List<MsUser> { users };
            DetailsViewProfile.DataBind();
        }

        protected void updatePasswordBtn_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();

            MsUser msUser = (MsUser)Session["IsAdmin"];

            int updateUserID = msUser.UserID;
            string oldPass = oldPassTB.Text;
            string newPass = newPassTB.Text;
            msgPassLbl.Text = UserController.UpdatePassword(updateUserID, oldPass, newPass);
        }
    }
}