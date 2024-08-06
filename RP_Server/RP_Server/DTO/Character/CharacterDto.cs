using RP_Server.Models;
using RP_Server.Models.Entities;

namespace RP_Server.DTO.Character
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CharacterType { get; set; }
        public string Owner { get; set; }
        public string Race { get; set; }
    }
}
