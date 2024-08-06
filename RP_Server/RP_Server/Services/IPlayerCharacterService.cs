using RP_Server.DTO.Character;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services
{
    public interface IPlayerCharacterService
    {
        public PlayerCharacterDto GetById(int id);
        public PlayerCharacterDto Create(PlayerCharacterCreateRequest request);
        public PlayerCharacterDto Update(PlayerCharacterDto request);
    }
}
