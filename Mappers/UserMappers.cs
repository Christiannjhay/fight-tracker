using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto  
            {
                UserId = userModel.UserId,
                Name = userModel.Name,
                Username = userModel.Username,
                Password = userModel.Password,
                Birthday = userModel.Birthday

            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Username = userDto.Username,
                Password = userDto.Password,
                Birthday = userDto.Birthday,

            };
        }
        
    }
}