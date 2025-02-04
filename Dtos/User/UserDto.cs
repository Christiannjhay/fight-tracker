using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int CoupleCode { get; set; }

        public DateTime Anniversary { get; set; }

        public DateTime Birthday { get; set; }
        
    }
}