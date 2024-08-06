using AutoMapper;
using RP_Server.DTO.Character;
using RP_Server.Models.Entities;
using RP_Server.Models.Repositories;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services.Implementation
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        private TokenService _tokenService;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper, TokenService tokenService)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public CharactersDto GetAll(string token)
        {
            var result = new CharactersDto();
            if (_tokenService.GetUserRoleFromToken(token) == "Admin")
            {
                result.Characters = _characterRepository.GetAll().Result.Select(_mapper.Map<CharacterDto>).ToList();
            }
            else
            {
                result.Characters = _characterRepository.GetAll().Result
                    .Where(x=>x.Owner.UserName == _tokenService.GetUserNameFromToken(token))
                    .Select(_mapper.Map<CharacterDto>)
                    .ToList();
            }
            return result;
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
