using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.Controllers
{
    internal class AssignRole
    {
        private IdentityRole role;
        private ApplicationUser role1;

        public AssignRole(IdentityRole role)
        {
            this.role = role;
        }

        public AssignRole(ApplicationUser role1)
        {
            this.role1 = role1;
        }

        public List<IdentityRole> Roles { get; set; }
    }
}