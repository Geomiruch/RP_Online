using AutoMapper;
using RP_Server.DTO.Character;
using RP_Server.Models.Entities;
using RP_Server.Models.Repositories;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services.Implementation
{
    public class HumanoidCharacterService : IHumanoidCharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public HumanoidCharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public HumanoidCharacterDto GetById(int id)
            => _mapper.Map<HumanoidCharacterDto>(_characterRepository.GetById(id));

        public HumanoidCharacterDto Create(HumanoidCharacterCreateRequest request)
            => _mapper.Map<HumanoidCharacterDto>(_characterRepository.Create(_mapper.Map<HumanoidCharacter>(request)));
        
        public HumanoidCharacterDto Update(HumanoidCharacterDto request)
            => _mapper.Map<HumanoidCharacterDto>(_characterRepository.Update(_mapper.Map<HumanoidCharacter>(request)));
    }
}
