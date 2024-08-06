using AutoMapper;
using RP_Server.DTO.Character;
using RP_Server.Models.Entities;
using RP_Server.Models.Repositories;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services.Implementation
{
    public class PlayerCharacterService : IPlayerCharacterService
    {
        ICharacterRepository _characterRepository;
        IMapper _mapper;

        public PlayerCharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public PlayerCharacterDto GetById(int id)
            => _mapper.Map<PlayerCharacterDto>(_characterRepository.GetById(id));

        public PlayerCharacterDto Create(PlayerCharacterCreateRequest request)
            => _mapper.Map<PlayerCharacterDto>(_characterRepository.Create(_mapper.Map<PlayerCharacter>(request)));

        public PlayerCharacterDto Update(PlayerCharacterDto request)
            => _mapper.Map<PlayerCharacterDto>(_characterRepository.Update(_mapper.Map<PlayerCharacter>(request)));
    }
}
