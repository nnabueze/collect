using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ErcasCollect.Commands.Dto
{
    public class BaseDto
    {

     
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public DateTime ModifiedDate { get; set; }= DateTime.UtcNow;

        
        public int ModifiedBy { get; set; }
        public int Createdby { get; set; }


    }
}
