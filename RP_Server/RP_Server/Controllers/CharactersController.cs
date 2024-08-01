using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RP_Server.DTO;
using RP_Server.Models.Entities;
using RP_Server.Models.Repositories;
using RP_Server.Requests.CreateRequsts;
using RP_Server.Services;

namespace RP_Server.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ILogger<CharactersController> logger, ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("new")]
        public async Task<ActionResult<Character>> CreateCharacter(CharacterCreateRequeest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var character = _characterService.Create(request);

            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }

        [HttpGet("all")]
        public ActionResult<CharactersDto> ListCharacters()
            => Ok(_characterService.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<CharacterDto> GetCharacter(int id)
            => Ok(_characterService.GetById(id));

    }
}
