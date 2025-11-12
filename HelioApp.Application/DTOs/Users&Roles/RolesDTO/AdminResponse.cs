using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Application.DTOs.Users_Roles.RolesDTO
{
    public class AdminResponse
    {
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string AccountType { get; set; } = "Admin";
        public string Status { get; set; } = "Active";
        public DateTimeOffset CreatedAt { get; set; }
    }
}
