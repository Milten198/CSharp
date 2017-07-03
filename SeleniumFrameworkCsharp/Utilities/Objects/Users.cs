using SeleniumFrameworkCsharp.Utilities.Configurations;
using System;

namespace SeleniumFrameworkCsharp.Utilities.Objects
{
    public sealed class Users
    {      
        private static Users Recent;

        public String username { get; set; }
        public String password { get; set; }

        public Users(String common)
        {
            this.username = common;
            this.password = common;
        }

        public Users(String username, String password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
