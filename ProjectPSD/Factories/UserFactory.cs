using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factories
{
    public class UserFactory
    {
        public static MsUser Create(int userID, string username, string userEmail, DateTime dob, string gender, string role, string password)
        {
            MsUser user = new MsUser();
            user.UserID = userID;
            user.UserName = username;
            user.UserEmail = userEmail;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserRole = role;
            user.UserPassword = password;
            return user;
        }
    }
}