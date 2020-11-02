using System;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Queries.Dto
{
    public class ReadPosDto
    {

        public OS OS { get; set; }
      
        public decimal Version { get; set; }

     
        public Biller Biller { get; set; }

        public LevelOne LevelOne { get; set; }


        public LevelTwo LevelTwo { get; set; }


        public User User { get; set; }

    }
}
