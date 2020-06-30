using CustomORM.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentity.CustomProvider.Data
{
    public class ApplicationUser
    {
        [PK]
        public int ID { get; set; }
        public string Username { get; set; }
        public string NormalizedUserName { get; set; }
        public string Password { get; set; }

        public ApplicationUser()
        {}

        public ApplicationUser(int ID, string Username, string NormalizedUserName, string Password)
        {
            this.ID = ID;
            this.Username = Username;
            this.NormalizedUserName = NormalizedUserName;
            this.Password = Password;
        }
    }
}
