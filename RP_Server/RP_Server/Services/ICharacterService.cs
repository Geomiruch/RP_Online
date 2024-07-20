using RP_Server.DTO;
using RP_Server.Models.Entities;

namespace RP_Server.Services
{
    public interface ICharacterService
    {
        public ICollection<CharacterDto> GetAll();
        public CharacterDto GetById(int id);
        public bool Delete(int id);
        public CharacterDto Create(CharacterDto request);
        public CharacterDto Update(CharacterDto request);
    }
}
