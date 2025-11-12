using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Application.DTOs.Users_Roles.UsersDTO
{
    public record UsersResponse(
     string Id,
     string Email,
     string UserName,
     string? PhoneNumber,
     string AccountType,
     string Status
 );
}
