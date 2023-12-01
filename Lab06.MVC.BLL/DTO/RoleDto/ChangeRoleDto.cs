using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Lab06.MVC.BLL.DTO
{
    public class ChangeRoleDto
    {
        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public List<IdentityRole> AllRoles { get; set; }

        public IList<string> UserRoles { get; set; }

        public ChangeRoleDto()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
