using AutoMapper;
using RP_Server.DTO;
using RP_Server.Models.Entities;
using RP_Server.Models.Repositories;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services.Implementation
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public CharactersDto GetAll()
        {
            var result = new CharactersDto();
            result.Characters = _characterRepository.GetAll().Result.Select(_mapper.Map<CharacterDto>).ToList();
            return result;
            return new CharactersDto().Characters = _characterRepository.GetAll().Result.Select(_mapper.Map<CharacterDto>).ToList();
        }
        public CharacterDto GetById(int id)
            => _mapper.Map<CharacterDto>(_characterRepository.GetById(id));

        public bool Delete(int id)
            => _characterRepository.Delete(id);

        public CharacterDto Create(CharacterCreateRequeest request)
            => _mapper.Map<CharacterDto>(_characterRepository.Create(_mapper.Map<Character>(request)));

        public CharacterDto Update(CharacterDto request)
            => _mapper.Map<CharacterDto>(_characterRepository.Update(_mapper.Map<Character>(request)));
    }
}
