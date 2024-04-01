using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Couple;
using api.Models;

namespace api.Mappers
{
    public static class CoupleMappers
    {
        public static CoupleDto ToCoupleDto(this Couple coupleModel)
        {
            return new CoupleDto  
            {
                CoupleId = coupleModel.CoupleId,
                CoupleCode = coupleModel.CoupleCode,
                Couple_1 = coupleModel.Couple_1,
                Couple_2 = coupleModel.Couple_2,
                Anniversary = coupleModel.Anniversary
                
            };
        }

    }
}