using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Repositories
{
    public enum EPolicy { Allow, Deny, Mandatory}

    public class Claim
    {
        public int Id { get; set; }

        //public int RoleId { get; set; }

        //public int PermissionId { get; set; }

        public EPolicy Policy { get; set; }

        public Role Role { get; set; }

        public Permission Permission { get; set; }
    }
}
