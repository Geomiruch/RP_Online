using RP_Server.Models;

namespace RP_Server.DTO
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string OwnerId { get; set; }
    }
}
