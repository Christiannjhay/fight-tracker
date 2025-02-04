using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class CreateUserRequestDto
    {
        
        public string Name { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        public bool IsCreatingCouple { get; set; }

        public DateTime Anniversary { get; set; }

        public int CoupleCode { get; set; }

        public int CoupleUserId { get; internal set; }
    }
}