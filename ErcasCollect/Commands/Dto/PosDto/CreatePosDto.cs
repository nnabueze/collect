using System;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Commands.Dto.PosDto
{
    public class CreatePosDto:BaseDto
    {
        public string Id { get; set; }
        public string OSId { get; set; }
   
        public string LevelOneId { get; set; }
 
        public string LevelTwoId { get; set; }

        public string BillerId { get; set; }

        public string StatusId { get; set; }
      
        public string Activationpin { get; set; }

        public decimal Version { get; set; }

  
     

  
    }
}
