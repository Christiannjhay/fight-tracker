using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Couple
{
    public class CoupleDto
    {
        public int CoupleId { get; set; }

        public int CoupleCode { get; set; }

        public int Couple_1 { get; set; }

        public int Couple_2 { get; set; }

        public DateTime Anniversary { get; set; }

    }
}