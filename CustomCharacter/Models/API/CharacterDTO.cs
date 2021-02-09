using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.API
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        [Required]

        public string UserId { get; set; }
        [Required]

        public int RaceId { get; set; }
        [Required]

        public int ClassId { get; set; }
        [Required]

        public string Name { get; set; }
        public int HP { get; set; }
        public int Dex { get; set; }
        public int Strength { get; set; }
        
        public AppUserDTO CharAppUserDTO { get; set; }
        public RaceDTO CharRaceDTO { get; set; }
        public ClassDTO CharClassDTO { get; set; }
    }
}
