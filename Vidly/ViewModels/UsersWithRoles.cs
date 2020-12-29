using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class UsersWithRoles
    {
        public List<UsersWithRoles> Users { get; set; }
        public ApplicationUser User { set; get; }
        public List<string> UserRoles { set; get; }

        public List<IdentityRole> Roles { set; get; }

        public string RoleId { get; set; }

        public RegisterViewModel RegisterUser { get; set; }

        public ResetPasswordViewModel ResetPassword { get; set; }

        

    }
}
