using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RP_Server.DTO.Character;
using RP_Server.Requests.CreateRequsts;
using RP_Server.Services;
using RP_Server.Services.Implementation;

namespace RP_Server.Controllers.Characters
{
    [ApiVersion(1.0)]
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PlayerCharactersController : ControllerBase
    {
        IPlayerCharacterService _playerCharacterService;

        public PlayerCharactersController(IPlayerCharacterService playerCharacterService)
        {
            _playerCharacterService = playerCharacterService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<PlayerCharacterDto> GetHumanoidCharacter(int id)
            => Ok(_playerCharacterService.GetById(id));

        [HttpPost("create")]
        public ActionResult<PlayerCharacterDto> CreateHumanoidCharacter(PlayerCharacterCreateRequest request)
            => Ok(_playerCharacterService.Create(request));

        [HttpPut("update")]
        public ActionResult<PlayerCharacterDto> UpdateHumanoidCharacter(PlayerCharacterDto request)
            => Ok(_playerCharacterService.Update(request));
    }
}
