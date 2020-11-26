using System;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public string Activationpin { get; set; }= Helpers.IdGenerator.IdGenerator.GetUniqueKey(4, 1);

        public decimal Version { get; set; }


        public string UserId { get; set; }




    }
}
