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
    public class HumanoidCharactersController : ControllerBase
    {
        IHumanoidCharacterService _humanoidCharacterService;

        public HumanoidCharactersController(IHumanoidCharacterService humanoidCharacterService)
        {
            _humanoidCharacterService = humanoidCharacterService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<HumanoidCharacterDto> GetHumanoidCharacter(int id)
            => Ok(_humanoidCharacterService.GetById(id));

        [HttpPost("create")]
        public ActionResult<HumanoidCharacterDto> CreateHumanoidCharacter(HumanoidCharacterCreateRequest request)
            => Ok(_humanoidCharacterService.Create(request));

        [HttpPut("update")]
        public ActionResult<HumanoidCharacterDto> UpdateHumanoidCharacter(HumanoidCharacterDto request)
            => Ok(_humanoidCharacterService.Update(request));
    }
}
