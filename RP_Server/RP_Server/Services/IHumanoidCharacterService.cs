using RP_Server.DTO;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services
{
    public interface IHumanoidCharacterService
    {
        public HumanoidCharacterDto GetById(int id);
        public HumanoidCharacterDto Create(HumanoidCharacterCreateRequest request);
        public HumanoidCharacterDto Update(HumanoidCharacterDto request);
    }
}
