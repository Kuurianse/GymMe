using ProjectPSD.Model;
using ProjectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Hadler
{
    public class UserHandler
    {
        public static MsUser doLogin(string username, string password)
        {
            MsUser user = UserRepository.login(username, password);
            return user;
        }

        public static Boolean doRegister(string username, string userEmail, string gender, string password, DateTime dob)
        {
            if (UserRepository.checkSameUsername(username) == null)
            {
                UserRepository.doRegister(username, userEmail, gender, password, dob);
                return true;
            }
            return false;
        }
    }
}