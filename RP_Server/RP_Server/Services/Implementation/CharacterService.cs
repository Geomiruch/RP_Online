using AutoMapper;
using RP_Server.DTO;
using RP_Server.Models.Entities;
using RP_Server.Models.Repositories;

namespace RP_Server.Services.Implementation
{
    public class CharacterService : ICharacterService
    {
        ICharacterRepository _characterRepository;
        IMapper _mapper;
        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public CharactersDto GetAll()
        {
            var result = new CharactersDto();
            result.Characters = _characterRepository.GetAll().Select(_mapper.Map<CharacterDto>).ToList();
            return result;
        }
        public CharacterDto GetById(int id)
        {
            return _mapper.Map<CharacterDto>(_characterRepository.GetById(id));
        }
        public bool Delete(int id)
        {
            return _characterRepository.Delete(id);
        }
        public CharacterDto Create(CharacterDto request)
        {
            var result = _characterRepository.Create(_mapper.Map<Character>(request));
            return _mapper.Map<CharacterDto>(result);
        }
        public CharacterDto Update(CharacterDto request)
        {
            var result = _characterRepository.Update(_mapper.Map<Character>(request));
            return _mapper.Map<CharacterDto>(result);
        }
    }
}
