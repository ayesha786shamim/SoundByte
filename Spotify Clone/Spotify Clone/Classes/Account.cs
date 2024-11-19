using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Clone.Classes
{
    internal abstract class Account
    {
        string id;
        string name;
        string password;
        string role;

        public void setId(string userId)
        {
            id=userId;
        }
        public void setName(string userName)
        {
            name = userName;
        }
        public void setPassword(string pass)
        {
            password = pass;    
        }
        public void setRole(string userRole)
        {
            role = userRole;    

        }
        public string getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public string getPassword()
        {
            return password;
        }
        public string getRole()
        {
            return role;
        }

    }
}
