using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Application.DTOs.Users_Roles.UsersDTO
{
    public class UpdateUserRequest
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string AccountType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
