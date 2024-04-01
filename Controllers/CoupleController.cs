using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/couple")]
    [ApiController]
    
    public class CoupleController :  ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CoupleController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult getAll()
        {
            var couples = _context.Couples.ToList()
            .Select(s => s.ToCoupleDto());

            return Ok(couples);
        }

    }
}