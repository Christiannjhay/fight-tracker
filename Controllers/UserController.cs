using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Couple;
using api.Dtos.User;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/register")]
    [ApiController]
    public class UserController :  ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        private static int GenerateRandomCoupleCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    
        [HttpGet]

        public IActionResult getAll()
        {
            var users = _context.Users.ToList()
            .Select(s => s.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users.Find(id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }
        
        //Create User and Couple if IsCreatingCouple is True,  Else Create User and Update Couple code if it matches the Couple Code  
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequestDto userDto)
        {
            if (userDto.IsCreatingCouple && userDto.CoupleCode == 0)
            {
                
                var userModel = userDto.ToUserFromCreateDTO();
                _context.Users.Add(userModel);
                _context.SaveChanges();

               
                var couple = new Couple
                {
                    Couple_1 = userModel.UserId,
                    Couple_2 = -1,
                    Anniversary = userDto.Anniversary,
                    CoupleCode = GenerateRandomCoupleCode()
                };

                _context.Couples.Add(couple);
                _context.SaveChanges();

               
                return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel.ToUserDto());
            }
            else
            {
               
                    var userModel = userDto.ToUserFromCreateDTO();
                    _context.Users.Add(userModel);
                    _context.SaveChanges();
                    var existingCouple = _context.Couples.FirstOrDefault(c => c.CoupleCode == userDto.CoupleCode);

                    if (existingCouple != null)
                    {

                        existingCouple.Couple_2 = userModel.UserId;
                        _context.SaveChangesAsync();

                        return Ok(new { message = "Couple updated successfully" });
                    }
                    else
                    {
                        
                        return BadRequest("Couple with code " + userDto.CoupleCode + " not found.");
                    }
 
            }
        }
        
        
        [HttpPut]
        [Route("{id}")]

        public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = _context.Users.FirstOrDefault(x => x.UserId == id);

            if (userModel == null)
            {
                return NotFound();
            }

            userModel.Name = updateDto.Name;
            userModel.Username = updateDto.Username;
            userModel.Password = updateDto.Password;
            userModel.Birthday = updateDto.Birthday;

            _context.SaveChanges();

            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var userModel = _context.Users.FirstOrDefault(x => x.UserId == id);

            if(userModel == null)
            {
                return NotFound();
                
            }

            _context.Users.Remove(userModel);

            _context.SaveChanges();

            return NoContent();
        }

    }
}