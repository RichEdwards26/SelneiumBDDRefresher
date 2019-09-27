using System;
using System.Collections.Generic;
using System.Text;

namespace SelneiumBDDRefresher.Data
{
    class UserDataModel
    {
        public string username;
        public string password;
        public string email;

        public void GenerateRandomUserDetails()
        {
            int random = new Random().Next(1, 99999);
            username = "TestUser_" + random;
            email = "TestUser_" + random + "@TestUser" + random + ".com";
            password = "Aut0m#ti0n";
        }

    }
}
