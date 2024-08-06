using RP_Server.DTO.Character;
using RP_Server.Models.Entities;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services
{
    public interface ICharacterService
    {
        public CharactersDto GetAll(string token);
        public CharacterDto GetById(int id);
        public bool Delete(int id);
        public CharacterDto Create(CharacterCreateRequeest request);
        public CharacterDto Update(CharacterDto request);
    }
}
